using Microsoft.EntityFrameworkCore;
using PortfolioServer.Data.Model;

namespace PortfolioServer.Data
{
    public class PortfolioServerContext : DbContext
    {
        public PortfolioServerContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Project>? Projects { get; set; }
        public DbSet<Skill>? Skills { get; set;}
        public DbSet<Role>? Roles { get; set;}
        public DbSet<ProjectSkill>? ProjectSkills { get; set; }
        public DbSet<ProjectRole>? ProjectRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //M-M Role/Skills
            modelBuilder.Entity<ProjectSkill>()
                .HasKey(ps => new { ps.ProjectId, ps.SkillId });

            modelBuilder.Entity<ProjectSkill>()
                .HasOne(ps => ps.Project)
                .WithMany(p => p.ProjectSkills)
                .HasForeignKey(ps => ps.ProjectId);

            modelBuilder.Entity<ProjectSkill>()
                .HasOne(ps => ps.Skill)
                .WithMany(s => s.ProjectSkills)
                .HasForeignKey(ps => ps.SkillId);

            //M-M Role/Projects
            modelBuilder.Entity<ProjectRole>()
                .HasKey(pr => new { pr.ProjectId, pr.RoleId });

            modelBuilder.Entity<ProjectRole>()
                .HasOne(pr => pr.Project)
                .WithMany(p => p.ProjectRoles)
                .HasForeignKey(pr => pr.ProjectId);

            modelBuilder.Entity<ProjectRole>()
                .HasOne(pr => pr.Role)
                .WithMany(r => r.ProjectRoles)
                .HasForeignKey(pr => pr.RoleId);
        }
    }
}