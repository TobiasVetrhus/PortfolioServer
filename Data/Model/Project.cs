using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PortfolioServer.Data.Model 
{
    public class Project 
    {
        [Key]
        public int ProjectId { get; set; }
        public string? CustomerSector { get; set; }
        public string? ProjectName { get; set; }
        public string? CustomerName { get; set; }
        public string? ProjectDescription { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // Navigation property for the many-to-many relationship with Skill
        public ICollection<ProjectSkill>? ProjectSkills { get; set; }

        // Navigation property for the many-to-many relationship with Role
        public ICollection<ProjectRole>? ProjectRoles { get; set; }
    }
}