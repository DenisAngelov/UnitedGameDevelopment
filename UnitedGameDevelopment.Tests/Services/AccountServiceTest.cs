namespace UnitedGameDevelopment.Tests.Services
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using UnitedGameDevelopment.Services;
    using UnitedGameDevelopment.Services.Contracts;
    using MockData;
    using Models.EntityModels;
    using Data.Contracts;

    [TestClass]
    public class AccountServiceTest
    {
        private IUnitOfWork uow;
        private IAccountService service;

        [TestInitialize]
        public void Setup()
        {
            this.uow = new FakeUnitOfWork();
            this.service = new AccountService(this.uow);
        }


        [TestMethod]
        public void CreateFreelancer_ShouldCreateFreelancer()
        {
            var appUser = new ApplicationUser()
            {
                UserName = "username",
            };
            this.uow.Users.Add(appUser);

            var freelancer = this.service.CreateFreelancer(appUser, "Freelancer");
            Assert.AreEqual("Freelancer", freelancer.FreelancerName);
            Assert.AreEqual("username", freelancer.User.UserName);

        }

        [TestMethod]
        public void CreateCompany_ShouldCreateCompany()
        {
            var appUser = new ApplicationUser()
            {
                UserName = "username",
            };
            this.uow.Users.Add(appUser);

            var comp = this.service.CreateCompany(appUser, "Company");
            Assert.AreEqual("Company", comp.CompanyName);
            Assert.AreEqual("username", comp.User.UserName);
        }
    }
}
