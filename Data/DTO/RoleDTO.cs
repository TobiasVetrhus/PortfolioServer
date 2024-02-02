using PortfolioServer.Data.Model;

namespace PortfolioServer.Data.DTO
{
    public class RoleDTO
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string? RoleDescription { get; set;}
    }
}