namespace UnitedGameDevelopment.Data
{
    using Contracts;
    using Models.EntityModels;

    public class UnitOfWork : IUnitOfWork
    {
        private UnitedGameDevelopmentContext context;
        private IRepository<Company> companies;
        private IRepository<Freelancer> freelancers;
        private IRepository<Project> projects;
        private IRepository<JobApplication> jobApplications;
        private IRepository<ApplicationUser> users;

        public UnitOfWork()
        {
            this.context = Data.Context;
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public IRepository<Company> Companies
            => this.companies ??
               (this.companies = new Repository<Company>(this.context.Companies));
        public IRepository<Freelancer> Freelancers
            => this.freelancers ??
               (this.freelancers = new Repository<Freelancer>(this.context.Freelancers));
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