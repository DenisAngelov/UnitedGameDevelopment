namespace UnitedGameDevelopment.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;

    public class UnitedGameDevelopmentContext : IdentityDbContext<ApplicationUser>
    {
        public UnitedGameDevelopmentContext()
            : base("data source=.;initial catalog=UnitedGameDevelopment;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework", throwIfV1Schema: false)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }

        public static UnitedGameDevelopmentContext Create()
        {
            return new UnitedGameDevelopmentContext();
        }


        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<WorkOffer>()
            .HasRequired(s => s.Project)
            .WithMany(s => s.WorkOffers);

            base.OnModelCreating(modelBuilder);
        }*/


    }
}