using GitLogAnalysis.Core.Aggregates.GitAgg.Entities;
using GitLogAnalysis.Core.Aggregates.GitAgg.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitLogAnalysis.Infra.Data.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
