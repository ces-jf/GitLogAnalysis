using GitLogAnalysis.Core.Aggregates.GitAgg.Dtos;
using GitLogAnalysis.Core.Aggregates.GitAgg.Entities;
using GitLogAnalysis.Core.Aggregates.GitAgg.Interfaces.Repositories;
using GitLogAnalysis.Core.Aggregates.GitAgg.Interfaces.Services;
using GitLogAnalysis.Core.SharedKernel.Entities;
using GitLogAnalysis.Core.SharedKernel.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitLogAnalysis.Core.Aggregates.GitAgg.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnityOfWork _unityOfWork;

        public ProjectService(IProjectRepository projectRepository, IUnityOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unityOfWork = unitOfWork;
        }

        public ResponseObject<Project> CreateProject(Project project)
        {
            var result = _projectRepository.Create(project);
            var commit = _unityOfWork.Commit();


            return commit
                ? new ResponseObject<Project>(true, obj: project)
                : new ResponseObject<Project>(false);

        }

        public void Delete(int idProject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetAllProjects()
        {
            var projects = _projectRepository.GetAll();

            return projects;
        }

        public Project GetProjectById(int idProject)
        {
            var project = _projectRepository.GetById(idProject);

            return project;
        }
    }
}
