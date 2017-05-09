namespace UnitedGameDevelopment.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<UnitedGameDevelopmentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(UnitedGameDevelopmentContext context)
        {
            
            string[] roles = {"User", "Freelancer", "Company", "Admin"};
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);

            foreach (var role in roles)
            {
                if (!context.Roles.Any(r => r.Name == role))
                {
                    var newRole = new IdentityRole(role);
                    manager.Create(newRole);
                }
            }

            /*
            Project project = new Project()
            {
                CompanyName = "Company",
                Description = "Connected cars, autonomous vehicle technologies, the Internet of things, " +
                              "embedded applications, Internet radio and mobile apps are just some of the " +
                              "cool things we work on at Abalta. We are pioneers in the navigation and mapping " +
                              "industry and have worked with over 60 global name brands since our inception. ",
                SkillsRequired = "Have both English written and speaking skills, Anticipate problems, take initiative, and assume responsibility",
                Budjet = 10000,
                Title =  "Towerfall",
                PublishDate = new DateTime(2016, 2, 15),
            };

            Project project2 = new Project()
            {
                CompanyName = "Company2",
                Description = "Connected cars, autonomous vehicle technologies, the Internet of things, " +
                              "embedded applications, Internet radio and mobile apps are just some of the " +
                              "cool things we work on at Abalta. We are pioneers in the navigation and mapping " +
                              "industry and have worked with over 60 global name brands since our inception. ",
                SkillsRequired = "Have both English written and speaking skills, Anticipate problems, take initiative, and assume responsibility",
                Budjet = 250000,
                Title = "Towerfall",
                PublishDate = new DateTime(2016, 2, 15),
            };

            Project project3 = new Project()
            {
                CompanyName = "Company3",
                Description = "Connected cars, autonomous vehicle technologies, the Internet of things, " +
                              "embedded applications, Internet radio and mobile apps are just some of the " +
                              "cool things we work on at Abalta. We are pioneers in the navigation and mapping " +
                              "industry and have worked with over 60 global name brands since our inception. ",
                SkillsRequired = "Have both English written and speaking skills, Anticipate problems, take initiative, and assume responsibility",
                Budjet = 1500,
                Title = "Towerfall",
                PublishDate = new DateTime(2016, 2, 15),
            };

            JobApplication jobApplication = new JobApplication()
            {
                FreelancerName = "Dev",
                Description = "I am a game developer",
                PublishDate = new DateTime(2014, 4, 27),
                SalaryPerHour = 16,
                SkillsAcquired = "C#, C++, Python",
                Title = "Game Dev"
            };

            context.Projects.AddOrUpdate(project);
            context.Projects.AddOrUpdate(project3);
            context.Projects.AddOrUpdate(project2);
            context.JobApplications.AddOrUpdate(jobApplication);

            context.SaveChanges(); */
        }
    }
}
