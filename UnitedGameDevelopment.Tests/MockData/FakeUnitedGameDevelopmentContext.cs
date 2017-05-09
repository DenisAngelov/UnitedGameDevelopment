namespace UnitedGameDevelopment.Tests.MockData
{
    using Models.EntityModels;

    public class FakeUnitedGameDevelopmentContext
    {
        public FakeUnitedGameDevelopmentContext()
        {
            this.Users = new FakeDbSet<ApplicationUser>();
            this.CompanyUsers = new FakeDbSet<Company>();
            this.FreelancerUsers = new FakeDbSet<Freelancer>();
            this.JobApplications = new FakeDbSet<JobApplication>();
            this.Projects = new FakeDbSet<Project>();
        }

        public FakeDbSet<ApplicationUser> Users { get; set; }
        public FakeDbSet<Company> CompanyUsers { get; set; }
        public FakeDbSet<Freelancer> FreelancerUsers { get; set; }
        public FakeDbSet<JobApplication> JobApplications { get; set; }
        public FakeDbSet<Project> Projects { get; set; }

        public static FakeUnitedGameDevelopmentContext Create()
        {
            return new FakeUnitedGameDevelopmentContext();
        }
    }
}