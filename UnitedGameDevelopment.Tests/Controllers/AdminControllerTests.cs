using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitedGameDevelopment.Tests.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using AutoMapper;
    using TestStack.FluentMVCTesting;
    using UnitedGameDevelopment.Data.Contracts;
    using UnitedGameDevelopment.Models.BindingModels;
    using UnitedGameDevelopment.Models.EntityModels;
    using UnitedGameDevelopment.Models.ViewModels.JobApplications;
    using UnitedGameDevelopment.Models.ViewModels.Manage;
    using UnitedGameDevelopment.Models.ViewModels.Projects;
    using UnitedGameDevelopment.Services;
    using UnitedGameDevelopment.Services.Contracts;
    using UnitedGameDevelopment.Tests.MockData;
    using UnitedGameDevelopment.Web.Areas.Admin.Controllers;

    [TestClass]
    public class AdminControllerTests
    {
        private IUnitOfWork uow;
        private IAdminService service;
        private AdminController controller;

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
            this.controller = new AdminController(this.service);
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
        public void Index_ShouldRenderDefaultView()
        {
            this.controller
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void Projects_ShouldRenderDefaultViewWithVm()
        {
            this.controller
                .WithCallTo(c => c.Projects())
                .ShouldRenderDefaultView()
                .WithModel<IEnumerable<ProjectVm>>();
        }

        [TestMethod]
        public void JobApplications_ShouldRenderDefaultViewWithVm()
        {
            this.controller
                .WithCallTo(c => c.JobApplications())
                .ShouldRenderDefaultView()
                .WithModel<IEnumerable<JobApplicationVm>>();
        }

        [TestMethod]
        public void CompanyUsers_ShouldRenderDefaultViewWithVm()
        {
            this.controller
                .WithCallTo(c => c.CompanyUsers())
                .ShouldRenderDefaultView()
                .WithModel<IEnumerable<CompanyUsersVm>>();
        }

        [TestMethod]
        public void FreelancerUsers_ShouldRenderDefaultViewWithVm()
        {
            this.controller
                .WithCallTo(c => c.FreelancerUsers())
                .ShouldRenderDefaultView()
                .WithModel<IEnumerable<FreelancerUserVm>>();
        }

        [TestMethod]
        public void DeleteCompany_ShouldRenderDefaultView()
        {
            this.controller
                .WithCallTo(c => c.DeleteCompany(0))
                .ShouldRenderDefaultView()
                .WithModel<Company>();
        }

        [TestMethod]
        public void DeleteCompany_ShouldRedirectToCompanyUsers()
        {
            this.controller
                .WithCallTo(c => c.DeleteCompany(0, new FormCollection()))
                .ShouldRedirectTo(c => c.CompanyUsers);
        }

        [TestMethod]
        public void DeleteFreelancer_ShouldRenderDefaultView()
        {
            this.controller
                .WithCallTo(c => c.DeleteFreelancer(0))
                .ShouldRenderDefaultView()
                .WithModel<Freelancer>();
        }

        [TestMethod]
        public void DeleteFreelancer_ShouldRedirectToCompanyUsers()
        {
            this.controller
                .WithCallTo(c => c.DeleteFreelancer(0, new FormCollection()))
                .ShouldRedirectTo(c => c.FreelancerUsers);
        }
    }
}
