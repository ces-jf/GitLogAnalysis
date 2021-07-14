using GitLogAnalysis.Core.Aggregates.GitAgg.Entities;
using GitLogAnalysis.Core.SharedKernel.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitLogAnalysis.Core.Aggregates.GitAgg.Interfaces.Repositories
{
    public interface IReleaseDataRepository : IRepository<ReleaseData>
    {
        IEnumerable<ReleaseData> GetReleaseByProject(int idProject);
    }
}
