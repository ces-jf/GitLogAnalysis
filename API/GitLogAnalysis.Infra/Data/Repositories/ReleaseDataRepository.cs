using GitLogAnalysis.Core.Aggregates.GitAgg.Entities;
using GitLogAnalysis.Core.Aggregates.GitAgg.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitLogAnalysis.Infra.Data.Repositories
{
    public class ReleaseDataRepository : Repository<ReleaseData>, IReleaseDataRepository
    {
        public ReleaseDataRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
