namespace UnitedGameDevelopment.Tests.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using Web.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestStack.FluentMVCTesting;
    using Models.BindingModels;
    using Models.EntityModels;
    using Models.ViewModels.JobApplications;
    using Models.ViewModels.Manage;
    using Models.ViewModels.Projects;
    using MockData;
    using Data.Contracts;
    using UnitedGameDevelopment.Services;
    using UnitedGameDevelopment.Services.Contracts;

    [TestClass]
    public class ProjectControllerTests
    {

        private ProjectController controller;
        private IProjectService service;
        private IUnitOfWork uow;

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Project, ProjectVm>();
                expression.CreateMap<JobApplication, JobApplicationVm>();
                expression.CreateMap<ProjectBm, Project>();
                expression.CreateMap<Company, CompanyUsersVm>();
                expression.CreateMap<Freelancer, FreelancerUserVm>();
            });
        }

        [TestInitialize]
        public void Setup()
        {
            this.ConfigureMapper();

            this.uow = new FakeUnitOfWork();
            this.service = new ProjectService(this.uow);
            this.controller = new ProjectController(this.service);
            this.InitializeData();
        }

        private void InitializeData()
        {
            ApplicationUser au = new ApplicationUser()
            {
                UserName = "AppUser"
            };

            Project project = new Project()
            {
                Title = "Le title"
            };

            Company company = new Company()
            {
                CompanyName = "Company",
                User = au
            };

            this.uow.Users.Add(au);
            this.uow.Companies.Add(company);
            this.uow.Projects.Add(project);
        }
        

        [TestMethod]
        public void Index_ShouldRenderDafultView()
        {
            this.controller.WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void Projects_ShouldRenderDefaultProjectsView()
        {
            this.controller.WithCallTo(c => c.Projects(null))
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void Details_ShouldRenderDefaultProjectView()
        {
            this.controller
                .WithCallTo(c => c.Details(0))
                .ShouldRenderDefaultView()
                .WithModel<ProjectVm>();
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
            ProjectBm projectBm = new ProjectBm()
            {
                Budjet = 2500,
                Description = "nope",
                SkillsRequired = "some skills, here",
                Title = "Title"
            };

            if (!this.controller.ModelState.IsValid)
            {
                this.controller
                .WithCallTo(c => c.Create(projectBm))
                .ShouldRenderDefaultView();
            }
        }

        [TestMethod]
        public void Edit_ShouldReturnDefaultViewWithVm()
        {
            this.controller
                .WithCallTo(c => c.Edit(0))
                .ShouldRenderDefaultView()
                .WithModel<Project>();
        }

        [TestMethod]
        public void Edit_ShouldRedirectToProjects()
        {
            ProjectBm projectBm = new ProjectBm()
            {
                Budjet = 2500,
                Description = "a lot of words a lot of words a lot of words a lot of words a lot of words",
                SkillsRequired = "some skills, here",
                Title = "Title"
            };

            this.controller
                .WithCallTo(c => c.Edit(0, projectBm))
                .ShouldRedirectTo(c => c.Projects(null));
        }

        [TestMethod]
        public void Edit_ShouldRenderDefaultView()
        {
            ProjectBm projectBm = new ProjectBm()
            {
                Budjet = 2500,
                Description = "a lot of words a lot of words a lot of words a lot of words a lot of words",
                SkillsRequired = "some skills, here",
                Title = "Title"
            };

            if (!this.controller.ModelState.IsValid)
            {
                this.controller
                .WithCallTo(c => c.Edit(0, projectBm))
                .ShouldRenderDefaultView()
                .WithModel<ProjectVm>();
            }
        }

        [TestMethod]
        public void Delete_ShouldRenderDefaultViewWithVm()
        {
            this.controller
                .WithCallTo(c => c.Delete(0))
                .ShouldRenderDefaultView()
                .WithModel<Project>();
        }

        [TestMethod]
        public void Delete_ShouldRedirectToProjects()
        {
            this.controller
                .WithCallTo(c => c.Delete(0, new FormCollection()))
                .ShouldRedirectTo(c => c.Projects(null));
        }

    }
}
