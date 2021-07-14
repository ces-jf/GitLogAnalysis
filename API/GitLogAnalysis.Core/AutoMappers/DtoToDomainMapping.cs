using GitLogAnalysis.Core.Aggregates.GitAgg.Dtos;
using GitLogAnalysis.Core.Aggregates.GitAgg.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitLogAnalysis.Core.AutoMappers
{
    public class DtoToDomainMapping : AutoMapper.Profile
    {
        public DtoToDomainMapping()
        {
            //CreateMap<Project, ProjectReleasesDto>();
            CreateMap<ReleaseData, ProjectReleasesDto>();
        }
    }
}
