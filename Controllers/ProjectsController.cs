using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioServer.Data;
using PortfolioServer.Data.DTO;
using PortfolioServer.Data.Model;

namespace PortfolioServer.Controllers
{
    [Route("projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectService _projectService;

        public ProjectsController(IMapper mapper, ProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects() 
        {
            var projects = await _projectService.GetProjectsAsync();
            return Ok(projects);
        }
    }
}