namespace UnitedGameDevelopment.Tests.MockData
{
    using Data.Contracts;
    using Models.EntityModels;
    using Data;

    public class FakeUnitOfWork : IUnitOfWork
    {
        private FakeUnitedGameDevelopmentContext context;
        private IRepository<Company> companies;
        private IRepository<Freelancer> freelancers;
        private IRepository<Project> projects;
        private IRepository<JobApplication> jobApplications;
        private IRepository<ApplicationUser> users;

        public FakeUnitOfWork()
        {
            this.context = new FakeUnitedGameDevelopmentContext();
            this.companies = new Repository<Company>(this.context.CompanyUsers);
            this.freelancers = new Repository<Freelancer>(this.context.FreelancerUsers);
            this.projects = new Repository<Project>(this.context.Projects);
            this.jobApplications = new Repository<JobApplication>(this.context.JobApplications);
            this.users = new Repository<ApplicationUser>(this.context.Users);
        }

        public int SaveChanges()
        {
            return 1;
        }

        public IRepository<Company> Companies
            => this.companies ??
               (this.companies = new Repository<Company>(this.context.CompanyUsers));
        public IRepository<Freelancer> Freelancers
            => this.freelancers ??
               (this.freelancers = new Repository<Freelancer>(this.context.FreelancerUsers));
        public IRepository<Project> Projects
            => this.projects ??
               (this.projects = new Repository<Project>(this.context.Projects));
        public IRepository<JobApplication> JobApplications
            => this.jobApplications ??
               (this.jobApplications = new Repository<JobApplication>(this.context.JobApplications));
        public IRepository<ApplicationUser> Users
            => this.users ??
               (this.users = new Repository<ApplicationUser>(this.context.Users));
    }
}