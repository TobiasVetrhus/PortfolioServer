using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortfolioServer.Data.DTO;
using PortfolioServer.Data.Exceptions;
using PortfolioServer.Data.Model;
using SQLitePCL;

namespace PortfolioServer.Data
{
    public class ProjectService
    {
        private readonly PortfolioServerContext _db;

        public ProjectService(PortfolioServerContext db)
        {
            _db = db;
        }
        public async Task<List<ProjectDTO>> GetProjectsAsync()
        {
            var projects = await _db.Projects
                .Include(p => p.ProjectSkills)
                    .ThenInclude(ps => ps.Skill)
                .Include(p => p.ProjectRoles)
                    .ThenInclude(pr => pr.Role)
                .ToListAsync();

            return projects.Select(p => new ProjectDTO
            {
                ProjectId = p.ProjectId,
                ProjectName = p.ProjectName,
                ProjectDescription = p.ProjectDescription,
                CustomerName = p.CustomerName,
                ImageUrl = p.ImageUrl,
                StartDate = p.StartDate,
                EndDate = p.EndDate,

                Skills = p.ProjectSkills.Select(ps => new SkillDTO
                {
                    SkillName = ps.Skill.SkillName
                }).ToList(),

                Roles = p.ProjectRoles.Select(pr => new RoleDTO
                {
                    RoleName = pr.Role.RoleName,
                    RoleDescription = pr.Role.RoleDescription
                }).ToList()
            }).ToList();
        }

        public async Task<ProjectDTO> GetProjectByIdAsync(int projectId)
        {
            if(!await ProjectExistsAsync(projectId))
                throw new EntityNotFoundException(nameof(Project), projectId);

            var project = await _db.Projects
                        .Include(p => p.ProjectSkills)
                            .ThenInclude(ps => ps.Skill)
                        .Include(p => p.ProjectRoles)
                            .ThenInclude(pr => pr.Role)
                        .FirstOrDefaultAsync();

            return new ProjectDTO
            {
                ProjectId = project.ProjectId,
                ProjectName = project.ProjectName,
                ProjectDescription = project.ProjectDescription,
                CustomerName = project.CustomerName,
                ImageUrl = project.ImageUrl,
                StartDate = project.StartDate,
                EndDate = project.EndDate,

                Skills = project.ProjectSkills.Select(ps => new SkillDTO
                {
                    SkillName = ps.Skill.SkillName
                }).ToList(),

                Roles = project.ProjectRoles.Select(pr => new RoleDTO
                {
                    RoleName = pr.Role.RoleName,
                    RoleDescription = pr.Role.RoleDescription
                }).ToList()
            };
        }

        //Helper methods
        public async Task<bool> ProjectExistsAsync(int id)
        {
            return await _db.Projects.AnyAsync(p => p.ProjectId == id);
        }
    }  
}
