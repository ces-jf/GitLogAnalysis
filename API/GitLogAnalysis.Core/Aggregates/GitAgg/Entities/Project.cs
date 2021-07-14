using GitLogAnalysis.Core.SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitLogAnalysis.Core.Aggregates.GitAgg.Entities
{
    public class Project : Entity
    {
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string Directory { get; set; }
        public virtual ICollection<ReleaseData> ReleaseDatas { get; set; }

    }
}
