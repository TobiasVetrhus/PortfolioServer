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
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProjects() 
        {
            var projects = await _projectService.GetProjectsAsync();
            return Ok(projects);
        }

        [HttpGet("{projectId}")]
        public async Task<ActionResult<ProjectDTO>> GetProject(int projectId)
        {
            var project = await _projectService.GetProjectByIdAsync(projectId);
            return Ok(project);
        }
    }
}