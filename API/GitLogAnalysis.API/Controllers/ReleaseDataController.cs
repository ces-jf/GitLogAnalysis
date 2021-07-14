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
        [HttpGet("{id}")]
        public IActionResult GetReleasesById([FromRoute] int id)
        {
            var result = _releaseDataService.GetReleaseById(id);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }


        [HttpGet("getReleaseByProject/{idProject}")]
        public IActionResult GetReleasesByProject([FromRoute] int idProject)
        {
            var result = _releaseDataService.GetReleaseByProject(idProject);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }


        [HttpPost("CreateRelease")]
        public IActionResult Main([FromBody]FrontParams frontParams)
        {
            var result = _releaseDataService.GetReleaseStats(frontParams);
            
            if (result.Success)
            {
                return Created("/ReleaseData", result.Object);
            }

            if (result.Message != null)
            {
                return BadRequest(new { error = result.Message });
            }
            return StatusCode(500);
        }


    }
}
