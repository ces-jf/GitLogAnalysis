using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitLogAnalysis.Core.Aggregates.GitAgg.Entities;
using GitLogAnalysis.Core.Aggregates.GitAgg.Interfaces.Services;
using GitLogAnalysis.Core.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GitLogAnalysis.API.Controllers
{
    [Route("[controller]")]
    public class ReleaseDataController : ControllerBase
    {
        private readonly IReleaseDataService _releaseDataService;

        public ReleaseDataController(IReleaseDataService releaseDataService)
        {
            _releaseDataService = releaseDataService;
        }

        [HttpGet]
        public IActionResult GetAllReleasesData()
        {
            var result = _releaseDataService.GetAllReleases();
            if (result != null)
                return Ok(result);
            return BadRequest();
        }


        [HttpPost]
        public IActionResult Main(FrontParams frontParams)
        {
            var result = _releaseDataService.GetReleaseStats(frontParams);

           // var resulta = _releaseDataService.GetAllReleases();
            if (result != null)
                return Ok(result);
            return BadRequest();
        }


    }
}
