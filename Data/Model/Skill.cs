using System.ComponentModel.DataAnnotations;

namespace PortfolioServer.Data.Model
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        public string? SkillName { get; set; }
        public ICollection<ProjectSkill>? ProjectSkills { get; set; }
    }
}