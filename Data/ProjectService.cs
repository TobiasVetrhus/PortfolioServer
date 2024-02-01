using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortfolioServer.Data.DTO;
using PortfolioServer.Data.Model;

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
                StartDate = p.StartDate ?? DateTime.MinValue, // Handle null StartDate
                EndDate = p.EndDate ?? DateTime.MinValue, // Handle null EndDate

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
    }  
}
