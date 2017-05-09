namespace UnitedGameDevelopment.Tests.Services
{
    using AutoMapper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Data.Contracts;
    using MockData;
    using Models.BindingModels;
    using Models.EntityModels;
    using Models.ViewModels.JobApplications;
    using Models.ViewModels.Manage;
    using Models.ViewModels.Projects;
    using UnitedGameDevelopment.Services;
    using UnitedGameDevelopment.Services.Contracts;

    [TestClass]
    public class AdminServiceTest
    {
        private IUnitOfWork uow;
        private IAdminService service;

        private void ConfigureMappings()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Project, ProjectVm>();
                expression.CreateMap<JobApplication, JobApplicationVm>();
                expression.CreateMap<ProjectBm, Project>();
                expression.CreateMap<Company, CompanyUsersVm>();
                expression.CreateMap<Freelancer, FreelancerUserVm>();
                expression.CreateMap<JobApplicationBm, JobApplication>();
            });
        }

        [TestInitialize]
        public void Setup()
        {
            this.ConfigureMappings();
            this.uow = new FakeUnitOfWork();
            this.service = new AdminService(this.uow);
            this.InitializeData();
        }

        private void InitializeData()
        {
            Company company = new Company()
            {
                CompanyName = "Company",
            };

            Freelancer freelancer = new Freelancer()
            {
                FreelancerName = "Freelancer"
            };

            this.uow.Companies.Add(company);
            this.uow.Freelancers.Add(freelancer);
        }

        [TestMethod]
        public void GetProjects_ShouldReturnProjects()
        {
            var projectVms = this.service.GetProjects();
            Assert.IsNotNull(projectVms);
        }

        [TestMethod]
        public void GetJobApplications_ShouldReturnJobApplications()
        {
            var jobAppVms = this.service.GetJobApplications();
            Assert.IsNotNull(jobAppVms);
        }

        [TestMethod]
        public void GetCompanyUsersVm_ShouldReturnCompanyVms()
        {
            var compUserVms = this.service.GetCompanyUsersVm();
            Assert.IsNotNull(compUserVms);
        }

        [TestMethod]
        public void GetFreelancerUsersVm_ShouldReturnFreelancerUserVms()
        {
            var freelancerUserVms = this.service.GetFreelancerUsersVm();
            Assert.IsNotNull(freelancerUserVms);
        }

        [TestMethod]
        public void GetCompany_ShouldReturnCompany()
        {
            var comp = this.service.GetCompany(0);
            Assert.AreNotEqual(null, comp);
            Assert.AreEqual("Company", comp.CompanyName);
        }

        [TestMethod]
        public void DeleteCompany_ShouldDeleteCompany()
        {
            var comp = this.service.GetCompany(0);
            this.service.DeleteCompany(comp);
            Assert.IsNull(this.service.GetCompany(0));
        }

        [TestMethod]
        public void GetFreelancer_ShouldReturnFreelancer()
        {
            var freelancer = this.service.GetFreelancer(0);
            Assert.AreNotEqual(null, freelancer);
            Assert.AreEqual("Freelancer", freelancer.FreelancerName);
        }

        [TestMethod]
        public void DeleteFreelancer_ShouldDeleteFreelancer()
        {
            var freelancer = this.service.GetFreelancer(0);
            this.service.DeleteFreelancer(freelancer);
            Assert.IsNull(this.service.GetFreelancer(0));
        }
    }
}
