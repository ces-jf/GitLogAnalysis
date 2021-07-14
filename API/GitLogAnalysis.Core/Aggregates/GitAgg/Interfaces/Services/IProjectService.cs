using GitLogAnalysis.Core.Aggregates.GitAgg.Dtos;
using GitLogAnalysis.Core.Aggregates.GitAgg.Entities;
using GitLogAnalysis.Core.SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitLogAnalysis.Core.Aggregates.GitAgg.Interfaces.Services
{
    public interface IProjectService
    {
        IEnumerable<Project> GetAllProjects();
        Project GetProjectById(int idProject);
        //void Delete(int idProject);
        //Project UpdateRelease(Project project);
        ResponseObject<Project> CreateProject(Project frontParams);
    }
}
