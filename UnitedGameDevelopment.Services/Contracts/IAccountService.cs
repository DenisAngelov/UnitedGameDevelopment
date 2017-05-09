namespace UnitedGameDevelopment.Services.Contracts
{
    using Models.EntityModels;

    public interface IAccountService
    {
        Freelancer CreateFreelancer(ApplicationUser user, string freelancerName);
        Company CreateCompany(ApplicationUser user, string companyName);
    }
}