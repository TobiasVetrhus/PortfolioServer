using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioServer.Data.Model
{
    public class ProjectSkill 
    {
        [Key]
        public int ProjectSkillId { get; set; }
        [ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }
        public Project? Project { get; set; }
        [ForeignKey(nameof(Skill))]
        public int SkillId { get; set; }
        public Skill? Skill { get; set; }
    }
}