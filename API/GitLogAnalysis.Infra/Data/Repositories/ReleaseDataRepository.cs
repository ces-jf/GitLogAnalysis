using GitLogAnalysis.Core.Aggregates.GitAgg.Entities;
using GitLogAnalysis.Core.Aggregates.GitAgg.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GitLogAnalysis.Infra.Data.Repositories
{
    public class ReleaseDataRepository : Repository<ReleaseData>, IReleaseDataRepository
    {
        public ReleaseDataRepository(DataContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<ReleaseData> GetReleaseByProject(int idProject)
        {
            var query = DbContext.ReleasesData.AsNoTracking().Where(x => x.IdProject == idProject).ToList();

            return query;
        }
    }
}
