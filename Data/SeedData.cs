using PortfolioServer.Data.Model;

namespace PortfolioServer.Data
{
    public static class SeedData 
    {
        public static void Initialize(PortfolioServerContext db)
        {
            var projects = new Project[]
            {
                new()
                {
                    ProjectId = 1,
                    ProjectName = "Digital Speed Interview",
                    ProjectDescription = "Digitalization of speed interview days held by Experis.",
                    CustomerName = "Experis",
                    StartDate = new DateTime(2023, 11, 1),
                    EndDate = new DateTime(2024, 2, 1)
                },
                new()
                {
                    ProjectId = 2,
                    ProjectName = "Humans VS Zombies",
                    ProjectDescription = "Game management system for Humans VS Zombies.",
                    CustomerName = "Noroff Accelerate",
                    StartDate = new DateTime(2023, 9, 1),
                    EndDate = new DateTime(2023, 11, 1)
                },
                new()
                {
                    ProjectId = 3,
                    ProjectName = "Success criteria for implementing No-Code AI in industrial companies.",
                    ProjectDescription = "Bachelor thesis in coperation with Intelecy, AIhub and collaborating industrial companies. The project included interviews and workshops to find barriers in industries abilities to adopt AI technologies like No-Code. The group also helped Vianode with data analysis of process data.",
                    CustomerName = "Intelecy, AIhub & Vianode",
                    StartDate = new DateTime(2023, 1, 1),
                    EndDate = new DateTime(2023, 6, 1)
                }
            };
            
            db.Projects.AddRange(projects);

            var skills = new Skill[]
            {
                new() { SkillId = 1, SkillName = "React" },
                new() { SkillId = 2, SkillName = "TypeScript" },
                new() { SkillId = 3, SkillName = "Tailwind" },
                new() { SkillId = 4, SkillName = ".NET" },
                new() { SkillId = 5, SkillName = "C#" },
                new() { SkillId = 6, SkillName = "API" },
                new() { SkillId = 7, SkillName = "Git" },
                new() { SkillId = 8, SkillName = "Project Management" },
                new() { SkillId = 9, SkillName = "Trello" },
                new() { SkillId = 10, SkillName = "JavaScript" },
                new() { SkillId = 11, SkillName = "Entity Framework" },
                new() { SkillId = 12, SkillName = "Keycloak" },
                new() { SkillId = 13, SkillName = "Jira" },
                new() { SkillId = 14, SkillName = "SSMS" },
                new() { SkillId = 15, SkillName = "Visual Studio" },
                new() { SkillId = 16, SkillName = "No-Code AI" },
                new() { SkillId = 17, SkillName = "Data Analysis" },
                new() { SkillId = 18, SkillName = "Service Design" },
                new() { SkillId = 19, SkillName = "Interviews" },
            };

            db.Skills.AddRange(skills);

            var projectSkills = new ProjectSkill[]
            {
                new(){ ProjectSkillId = 1, ProjectId = 1, SkillId = 1 },
                new(){ ProjectSkillId = 2, ProjectId = 1, SkillId = 2 },
                new(){ ProjectSkillId = 3, ProjectId = 1, SkillId = 3 },
                new(){ ProjectSkillId = 4, ProjectId = 1, SkillId = 4 },
                new(){ ProjectSkillId = 5, ProjectId = 1, SkillId = 5 },
                new(){ ProjectSkillId = 6, ProjectId = 1, SkillId = 6 },
                new(){ ProjectSkillId = 7, ProjectId = 1, SkillId = 7 },
                new(){ ProjectSkillId = 8, ProjectId = 1, SkillId = 8 },
                new(){ ProjectSkillId = 9, ProjectId = 1, SkillId = 9 },
                new(){ ProjectSkillId = 10, ProjectId = 2, SkillId = 4 },
                new(){ ProjectSkillId = 11, ProjectId = 2, SkillId = 6 },
                new(){ ProjectSkillId = 12, ProjectId = 2, SkillId = 10 },
                new(){ ProjectSkillId = 13, ProjectId = 2, SkillId = 11 },
                new(){ ProjectSkillId = 14, ProjectId = 2, SkillId = 12 },
                new(){ ProjectSkillId = 15, ProjectId = 2, SkillId = 13 },
                new(){ ProjectSkillId = 16, ProjectId = 2, SkillId = 14 },
                new(){ ProjectSkillId = 17, ProjectId = 2, SkillId = 15 },
                new(){ ProjectSkillId = 18, ProjectId = 2, SkillId = 1 },
                new(){ ProjectSkillId = 19, ProjectId = 3, SkillId = 16 },
                new(){ ProjectSkillId = 20, ProjectId = 3, SkillId = 17 },
                new(){ ProjectSkillId = 21, ProjectId = 3, SkillId = 18 },
                new(){ ProjectSkillId = 22, ProjectId = 3, SkillId = 19 },
            };

            db.ProjectSkills.AddRange(projectSkills);

            var roles = new Role[]
            {
                new() { RoleId = 1, RoleName = "Fullstack Developer" },
                new() { RoleId = 2, RoleName = "Git Master" },
                new() { RoleId = 3, RoleName = "Project Member" },
                new() { RoleId = 4, RoleName = "UX Designer" },
            };

            db.Roles.AddRange(roles);

            var projectRoles = new ProjectRole[]
            {
                new() {ProjectRoleId = 1, ProjectId = 1, RoleId = 1 },
                new() {ProjectRoleId = 2, ProjectId = 1, RoleId = 2 },
                new() {ProjectRoleId = 3, ProjectId = 2, RoleId = 1 },
                new() {ProjectRoleId = 5, ProjectId = 3, RoleId = 3 }
            };
            
            db.ProjectRoles.AddRange(projectRoles);

            db.SaveChanges();
        }
    }
}