using GitLogAnalysis.Core.Aggregates.GitAgg.Entities;
using GitLogAnalysis.Core.SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitLogAnalysis.Core.Aggregates.GitAgg.Interfaces.Services
{
    public interface IReleaseDataService
    {
        IEnumerable<ReleaseData> GetAllReleases();
        ReleaseData CreateRelease(ReleaseData release);
        ReleaseData GetReleasyById(int idRelease);
        void Delete(int idRelease);
        ReleaseData UpdateRelease(ReleaseData release);
        ReleaseData GetReleaseStats(FrontParams frontParams);
    }
}
