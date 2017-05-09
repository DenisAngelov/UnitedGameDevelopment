namespace UnitedGameDevelopment.Tests.Services
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using AutoMapper;
    using MockData;
    using Models.EntityModels;
    using Models.BindingModels;
    using Models.ViewModels.Manage;
    using Models.ViewModels.Projects;
    using Data.Contracts;
    using UnitedGameDevelopment.Services;
    using UnitedGameDevelopment.Services.Contracts;

    [TestClass]
    public class ProjectServiceTest
    {
        private IUnitOfWork uow;
        private IProjectService service;

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Project, ProjectVm>();
                expression.CreateMap<ProjectBm, Project>();
                expression.CreateMap<Company, CompanyUsersVm>();
            });
        }

        [TestInitialize]
        public void Setup()
        {
            this.ConfigureMapper();
            this.uow = new FakeUnitOfWork();
            this.service = new ProjectService(this.uow);
            this.InitializeData();
        }

        private void InitializeData()
        {
            ApplicationUser au = new ApplicationUser()
            {
                UserName = "Username"
            };

            Company company = new Company()
            {
                CompanyName = "CompName",
                Projects = new List<Project>(),
                User = au
            };

            Project pro = new Project()
            {
                Budjet = 2500,
                CompanyName = "CompName",
                Description = "Some really long text Some really long text Some really long text Some really long text",
                PublishDate = DateTime.Now,
                SkillsRequired = "some, skills",
                Title = "Le Title"
            };

            this.uow.Companies.Add(company);
            this.uow.Projects.Add(pro);
        }

        [TestMethod]
        public void GetCompany_ShouldReturnCompany()
        {
            var comp = this.service.GetCompany("Username");
            Assert.AreEqual("CompName", comp.CompanyName);
        }

        [TestMethod]
        public void GetCompany_ShouldReturnNull()
        {
            var comp = this.service.GetCompany("NoSuchName");
            Assert.AreEqual(null, comp);
        }

        [TestMethod]
        public void GetProject_ShoulReturnProject()
        {
            var project = this.service.GetProject(0);
            Assert.AreEqual("Le Title", project.Title);
        }

        [TestMethod]
        public void GetProject_ShoulReturnNull()
        {
            var project = this.service.GetProject(-1);
            Assert.AreEqual(null, project);
        }

        [TestMethod]
        public void ProjectVm_ShouldReturnProjectVm()
        {
            var projectVm = this.service.GetProjectVm(0);
            Assert.AreNotEqual(null, projectVm);
        }

        [TestMethod]
        public void ProjectVm_ShouldReturnNull()
        {
            var projectVm = this.service.GetProjectVm(-1);
            Assert.AreEqual(null, projectVm);
        }

        [TestMethod]
        public void GetProjects_ShouldReturnProjects()
        {
            var projectVms = this.service.GetProjects();
            Assert.IsNotNull(projectVms);
        }

        [TestMethod]
        public void GetMyProjects_ShouldReturnCompProjects()
        {
            var company = this.service.GetCompany("Username");
            var projectVms = this.service.GetMyProjects(company);
            Assert.IsNotNull(projectVms);
        }

        [TestMethod]
        public void CreateProject_ShouldSucceed()
        {
            var comp = this.service.GetCompany("Username");
            var projectBm = new ProjectBm()
            {
                Budjet = 1111,
                Description = "Some unique text Some unique text Some unique text Some unique text Some unique text",
                SkillsRequired = "unique skills, required",
                Title = "Unique Title"
            };

            this.service.CreateProject(projectBm, comp);
            Assert.AreEqual(2, this.uow.Projects.Count());
        }

        [TestMethod]
        public void EditProject_ShouldSucceed()
        {
            var projectBm = new ProjectBm()
            {
                Budjet = 1111,
                Description = "Some unique text Some unique text Some unique text Some unique text Some unique text",
                SkillsRequired = "unique skills, required",
                Title = "New Title"
            };

            this.service.EditProject(0, projectBm);
            Assert.AreEqual("New Title", this.service.GetProject(0).Title);
        }

        [TestMethod]
        public void DeleteProject_ShouldSucceed()
        {
            this.service.DeleteProject(this.service.GetProject(0));
            var project = this.service.GetProject(0);
            Assert.AreEqual(null, project);
        }

        [TestMethod]
        public void GetPaginationProjectVm_ShouldNotBeNull()
        {
            var paginationVms = this.service.GetPaginationProjectVm(null);
            Assert.IsNotNull(paginationVms);
        }

        [TestMethod]
        public void GetEditablePaginationProjectVm_ShouldNotBeNull()
        {
            var editablePaginationVms = this.service.GetEditablePaginationProjectVm(null, "Username");
            Assert.IsNotNull(editablePaginationVms);
        }
    }
}
