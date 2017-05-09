namespace UnitedGameDevelopment.Tests.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Data.Contracts;
    using Models.BindingModels;
    using Models.EntityModels;
    using Models.ViewModels.JobApplications;
    using TestStack.FluentMVCTesting;
    using UnitedGameDevelopment.Services;
    using UnitedGameDevelopment.Services.Contracts;
    using MockData;
    using Web.Controllers;

    [TestClass]
    public class JobApplicationsControllerTests
    {
        private IUnitOfWork uow;
        private IJobApplicationService service;
        private JobApplicationsController controller;

        private void ConfigureMappings()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<JobApplication, JobApplicationVm>();
                expression.CreateMap<JobApplicationBm, JobApplication>();
            });
        }

        [TestInitialize]
        public void Setup()
        {
            this.ConfigureMappings();
            this.uow = new FakeUnitOfWork();
            this.service = new JobApplicationService(this.uow);
            this.controller = new JobApplicationsController(this.service);
            this.InitializeData();
        }

        private void InitializeData()
        {
            JobApplication jobApp = new JobApplication()
            {
                Description = "a lot of words a lot of words a lot of words a lot of words a lot of words",
                Title = "Title",
                SalaryPerHour = 16,
                SkillsAcquired = "some skills, inserted"
            };

            this.uow.JobApplications.Add(jobApp);
        }

        [TestMethod]
        public void Index_ShouldRenderDefaultView()
        {
            this.controller
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void JobApplications_ShouldRenderDefaultProjectsView()
        {
            this.controller.WithCallTo(c => c.JobApplications(null))
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void Details_ShouldRenderDefaultProjectView()
        {
            this.controller
                .WithCallTo(c => c.Details(0))
                .ShouldRenderDefaultView()
                .WithModel<JobApplicationVm>();
        }

        [TestMethod]
        public void Create_ShouldRenderDefaultView()
        {
            this.controller
                .WithCallTo(c => c.Create())
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void Create_ShouldRedirectToDefaultView()
        {
            JobApplicationBm jobAppBm = new JobApplicationBm()
            {
                Description = "nope"
            };

            if (!this.controller.ModelState.IsValid)
            {
                this.controller
                .WithCallTo(c => c.Create(jobAppBm))
                .ShouldRenderDefaultView();
            }
        }

        [TestMethod]
        public void Edit_ShouldReturnDefaultViewWithVm()
        {
            this.controller
                .WithCallTo(c => c.Edit(0))
                .ShouldRenderDefaultView()
                .WithModel<JobApplication>();
        }

        [TestMethod]
        public void Edit_ShouldRedirectToJobApplications()
        {
            JobApplicationBm jobAppBm = new JobApplicationBm()
            {
                Description = "a lot of words a lot of words a lot of words a lot of words a lot of words",
                Title = "Title",
                SalaryPerHour = 16,
                SkillsAcquired = "some skills, inserted"
            };

            this.controller
                .WithCallTo(c => c.Edit(0, jobAppBm))
                .ShouldRedirectTo(c => c.JobApplications(null));
        }

        [TestMethod]
        public void Edit_ShouldRenderDefaultView()
        {
            JobApplicationBm jobAppBm = new JobApplicationBm()
            {
                Description = "nope",
                Title = "Title",
                SalaryPerHour = 16,
                SkillsAcquired = "some skills, inserted"
            };

            if (!this.controller.ModelState.IsValid)
            {
                this.controller
                .WithCallTo(c => c.Edit(0, jobAppBm))
                .ShouldRenderDefaultView()
                .WithModel<JobApplicationVm>();
            }
        }

        [TestMethod]
        public void Delete_ShouldRenderDefaultViewWithVm()
        {
            this.controller
                .WithCallTo(c => c.Delete(0))
                .ShouldRenderDefaultView()
                .WithModel<JobApplication>();
        }

        [TestMethod]
        public void Delete_ShouldRedirectToProjects()
        {
            this.controller
                .WithCallTo(c => c.Delete(0, new FormCollection()))
                .ShouldRedirectTo(c => c.JobApplications(null));
        }
    }
}
