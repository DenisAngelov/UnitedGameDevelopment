namespace UnitedGameDevelopment.Services
{
    using Models.EntityModels;
    using Contracts;
    using Data.Contracts;

    public class AccountService : Service, IAccountService
    {
        public AccountService(IUnitOfWork context) 
            : base(context)
        {
        }

        public Freelancer CreateFreelancer(ApplicationUser user, string freelancerName)
        {
            Freelancer freelancer = new Freelancer();
            ApplicationUser currUser = this.Context.Users.FirstOrDefault(u => u.Id == user.Id);
            freelancer.User = currUser;
            freelancer.FreelancerName = freelancerName;
            this.Context.Freelancers.Add(freelancer);
            this.Context.SaveChanges();

            return freelancer;
        }

        public Company CreateCompany(ApplicationUser user, string companyName)
        {
            Company company = new Company();
            ApplicationUser currUser = this.Context.Users.FirstOrDefault(u => u.Id == user.Id);
            company.User = currUser;
            company.CompanyName = companyName;
            this.Context.Companies.Add(company);
            this.Context.SaveChanges();

            return company;
        }
    }
}