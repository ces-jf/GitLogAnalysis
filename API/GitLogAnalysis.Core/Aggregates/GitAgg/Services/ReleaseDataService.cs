using GitLogAnalysis.Core.Aggregates.GitAgg.Dtos;
using GitLogAnalysis.Core.Aggregates.GitAgg.Entities;
using GitLogAnalysis.Core.Aggregates.GitAgg.Interfaces.Repositories;
using GitLogAnalysis.Core.Aggregates.GitAgg.Interfaces.Services;
using GitLogAnalysis.Core.SharedKernel.Entities;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GitLogAnalysis.Core.Aggregates.GitAgg.Services
{
    public class ReleaseDataService : IReleaseDataService
    {
        private readonly IReleaseDataRepository _releaseDataRepository;

        public ReleaseDataService(IReleaseDataRepository releaseDataRepository)
        {
            _releaseDataRepository = releaseDataRepository;
        }

        public ReleaseData GetReleaseStats(FrontParams frontParams)
        {
            string directory = "Z:/MeusArquivos/Faculdade/TCC/Torvalds/linux"; // directory of the git repository
            frontParams.InitialDate = new DateTime(2020, 05, 13);
            frontParams.FinalDate = new DateTime(2020, 05, 17);

            var initialDate = frontParams.InitialDate.ToString("yyyy-MM-dd");
            var finalDate = frontParams.FinalDate.ToString("yyyy-MM-dd");

            using (PowerShell powershell = PowerShell.Create())
            {
                //var contrabarra = "\\";
                // var cmd = "| sed 's/" + aspas + " /" + contrabarra + aspas + "/g' | sed 's/" + contrabarra + "^^^^/" + aspas + " / g'";

                var before = $@"--until ""{finalDate}""";
                var after = $@"--since ""{initialDate}""";
                var dateFormat = $@"--date=format:'%Y-%m-%d %H:%M:%S'";

                // var cmdstring = @"git log " + after + " " + before + " --pretty=format:'{^^^^date^^^^:^^^^%ci^^^^,^^^^authorname^^^^:^^^^%an^^^^,^^^^authoremail^^^^:^^^^%ae^^^^,^^^^commit^^^^:^^^^%h^^^^,^^^^subject^^^^:^^^^%s^^^^,^^^^TAG^^^^:^^^^%S^^^^},' | sed 's/""/\\""/g' | sed 's/\^^^^/""/g' > GITlog.json";
                //var cmdstring2 = @"git log --before "" "" --pretty=format:'{^^^^date^^^^:^^^^%ci^^^^,^^^^abbreviated_commit^^^^:^^^^%h^^^^,^^^^subject^^^^:^^^^%s^^^^,^^^^TAG^^^^:^^^^%S^^^^},' | sed 's/" + aspas + @" /\\" + aspas + @"/g' | sed 's/\^^^^/" + aspas + @" / g' > GITlog.json";
                //gitLogCmd.Append("git log  --pretty=format:'{^^^^date^^^^:^^^^%ci^^^^,^^^^abbreviated_commit^^^^:^^^^%h^^^^,^^^^subject^^^^:^^^^%s^^^^,^^^^TAG^^^^:^^^^%S^^^^},' {0} > GITlog.json");

                var cmdstring = @"git log " + after + " " + before + " " + dateFormat + " --pretty=format:'{&Date&:&%cd&,&AuthorName&:&%an&,&AuthorEmail&:&%ae&,&CommitHash&:&%h&}' > gitlog.txt";

                powershell.AddScript($"cd {directory}");
                powershell.AddScript("[console]::OutputEncoding = [System.Text.Encoding]::UTF8");
                powershell.AddScript(cmdstring);

                PSDataCollection<PSObject> results = powershell.InvokeAsync().GetAwaiter().GetResult();
            }
            var stringJson = File.ReadAllText($"{directory}/gitlog.txt");
            var aspas = "\"";

            //foreach (var item in results)
            //{
            //    stringJson = stringJson != "" ? $"{stringJson},{item.BaseObject}" : $"{stringJson}{item.BaseObject}";
            //}
            stringJson = $"[{stringJson}]";

            var powershellOutput = Regex.Replace(stringJson.ToString(), @"[&]", aspas).Replace("\r\n", ",");
            //powershellOutput.Replace("\n\r", "");
            var json = JsonConvert.SerializeObject(powershellOutput);
            var jsonResponse = JsonConvert.DeserializeObject(json).ToString();
            var jsonResponseFinal = JsonConvert.DeserializeObject<List<CommitForReleaseDto>>(jsonResponse);


            return null;

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

        public ReleaseData GetReleasyById(int idRelease)
        {
            var candidato = _releaseDataRepository.GetById(idRelease);

            return candidato;
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
