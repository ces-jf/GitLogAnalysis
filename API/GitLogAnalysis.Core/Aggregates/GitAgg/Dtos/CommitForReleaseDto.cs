using System;
using System.Collections.Generic;
using System.Text;

namespace GitLogAnalysis.Core.Aggregates.GitAgg.Dtos
{
    public class CommitForReleaseDto
    {
        public string CommitHash { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
        public DateTime Date { get; set; }
        public int IdProject { get; set; }


    }
}
