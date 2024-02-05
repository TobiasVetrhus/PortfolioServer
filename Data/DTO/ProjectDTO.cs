using PortfolioServer.Data.Model;

namespace PortfolioServer.Data.DTO
{
    public class ProjectDTO
    {
        public int ProjectId { get; set; }
        public string? CustomerSector { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectDescription { get; set; }
        public string? CustomerName { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<SkillDTO>? Skills { get; set; }
        public List<RoleDTO>? Roles { get; set; }
    }
}