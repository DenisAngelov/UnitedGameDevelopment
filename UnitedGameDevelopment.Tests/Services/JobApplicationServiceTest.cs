namespace UnitedGameDevelopment.Tests.Services
{
    using AutoMapper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Data.Contracts;
    using Models.BindingModels;
    using Models.EntityModels;
    using Models.ViewModels.JobApplications;
    using Models.ViewModels.Manage;
    using UnitedGameDevelopment.Services;
    using UnitedGameDevelopment.Services.Contracts;
    using MockData;

    [TestClass]
    public class JobApplicationServiceTest
    {
        private IUnitOfWork uow;
        private IJobApplicationService service;

        private void ConfigureMappings()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<JobApplication, JobApplicationVm>();
                expression.CreateMap<Freelancer, FreelancerUserVm>();
                expression.CreateMap<JobApplicationBm, JobApplication>();
            });
        }

        [TestInitialize]
        public void Setup()
        {
            this.ConfigureMappings();
            this.uow = new FakeUnitOfWork();
            this.service = new JobApplicationService(this.uow);
            this.InitializeData();
        }

        private void InitializeData()
        {
            ApplicationUser au = new ApplicationUser()
            {
                UserName = "AppUser"
            };

            JobApplication ja = new JobApplication()
            {
                Title = "Le title"
            };

            Freelancer freelancer = new Freelancer()
            {
                FreelancerName = "Freelancer",
                User = au
            };

            this.uow.Users.Add(au);
            freelancer.JobApplications.Add(ja);
            this.uow.Freelancers.Add(freelancer);
            this.uow.JobApplications.Add(ja);
        }

        [TestMethod]
        public void GetFreelancer_ShouldReturnFreelancer()
        {
            var freelancer = this.service.GetFreelancer("AppUser");
            Assert.AreEqual("Freelancer", freelancer.FreelancerName);
            Assert.AreEqual("AppUser", freelancer.User.UserName);
        }

        [TestMethod]
        public void GetFreelancer_ShouldReturnFreelancer_ShouldReturnNull()
        {
            var freelancer = this.service.GetFreelancer("NoSuchUser");
            Assert.IsNull(freelancer);
        }

        [TestMethod]
        public void GetJobApplication_ShouldReturnJobApplication()
        {
            var jobApplication = this.service.GetJobApplication(0);
            Assert.IsNotNull(jobApplication);
            Assert.AreEqual("Le title", jobApplication.Title);
        }

        [TestMethod]
        public void GetJobApplication_ShouldReturnNull()
        {
            var jobApplication = this.service.GetJobApplication(-1);
            Assert.IsNull(jobApplication);
        }

        [TestMethod]
        public void GetJobApplicationVm_ShouldReturnJobApplicationVm()
        {
            var jobAppVm = this.service.GetJobApplicationVm(0);
            Assert.IsNotNull(jobAppVm);
            Assert.AreEqual("Le title", this.service.GetJobApplication(0).Title);
        }

        [TestMethod]
        public void GetJobApplicationVm_ShouldReturnNull()
        {
            var jobAppVm = this.service.GetJobApplicationVm(-1);
            Assert.IsNull(jobAppVm);
        }

        [TestMethod]
        public void GetJobApplications_ShouldReturnJobApplications()
        {
            var jobApps = this.service.GetJobApplications();
            Assert.IsNotNull(jobApps);
        }

        [TestMethod]
        public void GetMyJobApplications_ShouldReturnFreelancerJobApplications()
        {
            var freelancer = this.service.GetFreelancer("AppUser");
            var freelancerJobApps = this.service.GetMyJobApplications(freelancer);
            Assert.IsNotNull(freelancerJobApps);
        }

        [TestMethod]
        public void CreateJobApplication_ShouldCreateJobApplication()
        {
            var jobAppBm = new JobApplicationBm()
            {
                Title = "New JobApp",
            };

            var freelancer = this.service.GetFreelancer("AppUser");

            this.service.CreateJobApplication(jobAppBm, freelancer);

            this.service.GetJobApplication(1);
            Assert.AreEqual(2, this.uow.JobApplications.Count());
        }

        [TestMethod]
        public void EditJobApplication_ShouldEditJobApplication()
        {
            var jobAppBm = new JobApplicationBm()
            {
                Title = "New Title"
            };

            this.service.EditJobApplication(0, jobAppBm);
            Assert.AreEqual("New Title", this.service.GetJobApplication(0).Title);
        }

        [TestMethod]
        public void DeleteApplication_ShouldDeleteJobApplication()
        {
            var jobApp = this.service.GetJobApplication(0);
            this.service.DeleteApplication(jobApp);
            Assert.AreEqual(0, this.uow.JobApplications.Count());
        }

        [TestMethod]
        public void GetPaginationApplicationVm_ShouldReturnPaginationApplicationVms()
        {
            var vms = this.service.GetPaginationApplicationVm(null);
            Assert.IsNotNull(vms);
        }

        [TestMethod]
        public void GetEditablePaginationApplicationVm_ShouldReturnEditablePaginationApplicationVms()
        {
            var editableVms = this.service.GetEditablePaginationApplicationVm(null, "AppUser");
            Assert.IsNotNull(editableVms);
        }
    }
}
