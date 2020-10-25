using System;
using System.Collections.Generic;
using System.Text;

namespace GitLogAnalysis.Core.SharedKernel.Entities
{
    public class FrontParams
    {
        public List<bool> Options { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public string ReleaseName { get; set; }
        public string FolderPath { get; set; }


    }
}
