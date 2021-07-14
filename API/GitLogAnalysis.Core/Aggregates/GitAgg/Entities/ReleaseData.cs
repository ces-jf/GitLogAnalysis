using GitLogAnalysis.Core.SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitLogAnalysis.Core.Aggregates.GitAgg.Entities
{
    public class ReleaseData : Entity
    {
        public string ReleaseName { get; set; }
        
        public int Authors { get; set; }
        public int Commits { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public int? RemovedLines { get; set; }
        public int? AddedLines { get; set; }
        public int IdProject { get; set; }
        public virtual Project Project { get; set; }
    }
}
