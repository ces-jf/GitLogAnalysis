using System;
using System.Collections.Generic;
using System.Text;

namespace GitLogAnalysis.Core.Aggregates.GitAgg.Dtos
{
    public class ProjectReleasesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Directory { get; set; }
        public virtual ICollection<ShortReleaseDto> Releases { get; set; }
    }
}
