using System.ComponentModel.DataAnnotations;

namespace PortfolioServer.Data.Model
{
    public class Role 
    {
        [Key]
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? RoleDescription { get; set; }

        public ICollection<ProjectRole>? ProjectRoles { get; set; }
    }
}