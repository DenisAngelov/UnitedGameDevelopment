namespace UnitedGameDevelopment.Data.Contracts
{
    using Models.EntityModels;

    public interface IUnitOfWork
    {
        int SaveChanges();
        IRepository<Company> Companies { get; }
        IRepository<Freelancer> Freelancers { get; }
        IRepository<Project> Projects { get; }
        IRepository<JobApplication> JobApplications { get; }
        IRepository<ApplicationUser> Users { get; }
    }
}