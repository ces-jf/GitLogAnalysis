using GitLogAnalysis.Core.Aggregates.GitAgg.Entities;
using GitLogAnalysis.Core.Aggregates.GitAgg.Interfaces.Services;
using GitLogAnalysis.Core.Aggregates.GitAgg.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitLogAnalysis.API.Controllers
{
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            var result = _projectService.GetAllProjects();
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
        [HttpGet("{id}")]
        public IActionResult GetProjectById([FromRoute] int id)
        {
            var result = _projectService.GetProjectById(id);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }


        [HttpPost("CreateProject")]
        public IActionResult CreateProject([FromBody] Project project)
        {
            var result = _projectService.CreateProject(project);

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
