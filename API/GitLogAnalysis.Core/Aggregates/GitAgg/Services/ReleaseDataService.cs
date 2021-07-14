using GitLogAnalysis.Core.Aggregates.GitAgg.Dtos;
using GitLogAnalysis.Core.Aggregates.GitAgg.Entities;
using GitLogAnalysis.Core.Aggregates.GitAgg.Interfaces.Repositories;
using GitLogAnalysis.Core.Aggregates.GitAgg.Interfaces.Services;
using GitLogAnalysis.Core.SharedKernel.Entities;
using GitLogAnalysis.Core.SharedKernel.Interfaces.UoW;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.PowerShell.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace GitLogAnalysis.Core.Aggregates.GitAgg.Services
{
    public class ReleaseDataService : IReleaseDataService
    {
        private readonly IReleaseDataRepository _releaseDataRepository;
        private readonly IUnityOfWork _unityOfWork;

        public ReleaseDataService(IReleaseDataRepository releaseDataRepository, IUnityOfWork unitOfWork)
        {
            _releaseDataRepository = releaseDataRepository;
            _unityOfWork = unitOfWork;
        }

        private static ProcessStartInfo CreateStartInfo(string command, string arguments, string workingDir, Encoding encoding = null)
        {
            return new ProcessStartInfo
            {
                UseShellExecute = false,
                ErrorDialog = false,
                CreateNoWindow = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                StandardOutputEncoding = encoding,
                StandardErrorEncoding = encoding,
                FileName = command,
                Arguments = arguments,
                WorkingDirectory = workingDir
            };
        }

        public ResponseObject<ReleaseData> GetReleaseStats(FrontParams frontParams)
        {

            //string directory = "Z:/MeusArquivos/Faculdade/TCC/Torvalds/linux"; // directory of the git repository
            // frontParams.InitialDate = new DateTime(2020, 05, 13);
            //frontParams.FinalDate = new DateTime(2020, 05, 17);
            //frontParams.FolderPath = directory;

            var initialDate = frontParams.InitialDate.ToString("yyyy-MM-dd");
            var finalDate = frontParams.FinalDate.ToString("yyyy-MM-dd");
            var before = $@"--until ""{finalDate}""";
            var after = $@"--since ""{initialDate}""";
            var dateFormat = $@"--date=format:'%Y-%m-%d %H:%M:%S'";
            var directory = Regex.Replace(frontParams.ProjectData.Directory, @"[\\]", "/");
           

            using (PowerShell powershell = PowerShell.Create())
            {

                // var contrabarra = "\\";
                // var cmd = "| sed 's/" + aspas + " /" + contrabarra + aspas + "/g' | sed 's/" + contrabarra + "^^^^/" + aspas + " / g'
                // var cmdstring = @"git log " + after + " " + before + " --pretty=format:'{^^^^date^^^^:^^^^%ci^^^^,^^^^authorname^^^^:^^^^%an^^^^,^^^^authoremail^^^^:^^^^%ae^^^^,^^^^commit^^^^:^^^^%h^^^^,^^^^subject^^^^:^^^^%s^^^^,^^^^TAG^^^^:^^^^%S^^^^},' | sed 's/""/\\""/g' | sed 's/\^^^^/""/g' > GITlog.json";
                // var cmdstring2 = @"git log --before "" "" --pretty=format:'{^^^^date^^^^:^^^^%ci^^^^,^^^^abbreviated_commit^^^^:^^^^%h^^^^,^^^^subject^^^^:^^^^%s^^^^,^^^^TAG^^^^:^^^^%S^^^^},' | sed 's/" + aspas + @" /\\" + aspas + @"/g' | sed 's/\^^^^/" + aspas + @" / g' > GITlog.json";
                // gitLogCmd.Append("git log  --pretty=format:'{^^^^date^^^^:^^^^%ci^^^^,^^^^abbreviated_commit^^^^:^^^^%h^^^^,^^^^subject^^^^:^^^^%s^^^^,^^^^TAG^^^^:^^^^%S^^^^},' {0} > GITlog.json");

                var cmdstring = @"git log " + after + " " + before + " " + dateFormat + " --pretty=format:'{&Date&:&%cd&,&AuthorName&:&%an&,&AuthorEmail&:&%ae&,&CommitHash&:&%h&}' > gitlog.txt";
                var cmdNumstat = "git log " + after + " " + before + @" --shortstat --oneline | ForEach{$_.Split("","")[1,2] ; } | Out-File foreach.txt";

                powershell.AddScript($"cd {directory}");
                powershell.AddScript("[console]::OutputEncoding = [System.Text.Encoding]::UTF8");
                powershell.AddScript(cmdstring);
                //Thread.Sleep(30000);
                powershell.AddScript(cmdNumstat);
                //Thread.Sleep(10000);


                PSDataCollection<PSObject> results = powershell.InvokeAsync().GetAwaiter().GetResult();
            }

            var stringJson = File.ReadAllText($"{directory}/gitlog.txt");
            var listNumstat = File.ReadLines($"{directory}/foreach.txt").ToList();
            var aspas = "\"";

            //foreach (var item in results)
            //{
            //    stringJson = stringJson != "" ? $"{stringJson},{item.BaseObject}" : $"{stringJson}{item.BaseObject}";
            //}

            stringJson = $"[{stringJson}]";
            var powershellOutput = Regex.Replace(stringJson.ToString(), @"[&]", aspas).Replace("\r\n", ",");

            var json = JsonConvert.SerializeObject(powershellOutput);
            var jsonResponse = JsonConvert.DeserializeObject(json).ToString();
            var objectList = JsonConvert.DeserializeObject<List<CommitForReleaseDto>>(jsonResponse);

            var addedLines = 0;
            var removedLines = 0;

            // var powershellOutput = Regex.Replace(stringJson.ToString(), @"[&]", aspas).Replace("\r\n", ",");

            foreach (var item in listNumstat)
            {
                if (item.Contains("(+)"))
                {
                    var numA = Int32.Parse(Regex.Match(item, @"[\d]").ToString());
                    addedLines = addedLines + numA;
                }
                else if (item.Contains("(-)"))
                {
                    var numR = Int32.Parse(Regex.Match(item, @"[\d]").ToString());
                    removedLines = removedLines + numR;
                }
            }

            ReleaseData release = new ReleaseData()
            {
                Authors = objectList.GroupBy(m => m.AuthorName).Count(),
                InitialDate = objectList.OrderBy(m => m.Date).FirstOrDefault().Date,
                FinalDate = objectList.OrderBy(m => m.Date).LastOrDefault().Date,
                RemovedLines = removedLines,
                AddedLines = addedLines,
                Commits = objectList.Count,
                ReleaseName = frontParams.ReleaseName,
                IdProject = frontParams.ProjectData.Id

            };
            _releaseDataRepository.Create(release);
            var commit = _unityOfWork.Commit();

            
            return commit
                ? new ResponseObject<ReleaseData>(true, obj: release)
                : new ResponseObject<ReleaseData>(false);



            //var stringLines = System.Windows.Markup.ValueSerializerAttribute.ReadLinesAsync(sampleFile);
            //var list = new List<string>();
            //var assembly = Assembly.GetExecutingAssembly();

            //using (Stream stream = assembly.GetManifestResourceStream($"{ directory}/foreach.txt"))
            //using (StreamReader reader = new StreamReader(stream))
            //{
            //    while (!reader.EndOfStream)
            //    {
            //        list.Add(reader.ReadLine());
            //    }
            //}
            //  return list;

            //gitInfo.Arguments = "git log " + after + " " + before + @" --shortstat --oneline | ForEach{$_.Split("","")[1,2] ; } | Out-File foreach.txt";
            //gitInfo.Arguments = $"cd {directory}";
            //gitInfo.Arguments = @"git log --pretty=tformat: --numstat | awk -F"" "" '{ added += $1; removed += $2 } END { print ""added: "",  added, ""removed: "", removed }'";
            //gitInfo.WorkingDirectory = directory;

        }

        public IEnumerable<ReleaseData> GetAllReleases()
        {
            var candidatos = _releaseDataRepository.GetAll().ToList();
            return candidatos.OrderByDescending(x => x.ReleaseName);
        }

        public ReleaseData CreateRelease(ReleaseData release)
        {
            if (release != null)
            {
                var releaseDb = _releaseDataRepository.Create(release);

                return releaseDb;
            }
            return null;
        }

        public ReleaseData GetReleaseById(int idRelease)
        {
            var release = _releaseDataRepository.GetById(idRelease);

            return release;
        }

        public IEnumerable<ReleaseData> GetReleaseByProject(int idProject)
        {
            var release = _releaseDataRepository.GetReleaseByProject(idProject);
            
            return release;
        }

        public void Delete(int idRelease)
        {
            _releaseDataRepository.Delete(idRelease);
        }

        public ReleaseData UpdateRelease(ReleaseData release)
        {

            if (release != null)
            {
                var releaseDb = _releaseDataRepository.Update(release);

                return releaseDb;

            }
            return null;
        }
    }
}
