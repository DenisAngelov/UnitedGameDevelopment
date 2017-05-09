namespace UnitedGameDevelopment.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Models.EntityModels;
    using Models.ViewModels.Projects;
    using Contracts;
    using Models.BindingModels;
    using Data.Contracts;
    using Models.ViewModels.Pagination;

    public class ProjectService : Service, IProjectService
    {
        public ProjectService(IUnitOfWork context) :
            base(context)
        {
        }

        public Company GetCompany(string username)
        {
            return this.Context.Companies.FirstOrDefault(au => au.User.UserName == username);
        }

        public ProjectVm GetProjectVm(int id)
        {
            Project project = this.GetProject(id);
            ProjectVm vm = Mapper.Map<Project, ProjectVm>(project);
            return vm;
        }

        public Project GetProject(int id)
        {
            return this.Context.Projects.FirstOrDefault(pro => pro.Id == id);
        }

        public IEnumerable<ProjectVm> GetProjects()
        {
            IEnumerable<Project> projects = this.Context.Projects.Entities;
            IEnumerable<ProjectVm> vms = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectVm>>(projects);
            return vms;
        }

        public IEnumerable<ProjectVm> GetMyProjects(Company company)
        {
            IEnumerable<Project> projects = company.Projects;
            IEnumerable<ProjectVm> vms = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectVm>>(projects);
            return vms;
        }

        public void CreateProject(ProjectBm bind, Company company)
        {
            Project project = Mapper.Map<ProjectBm, Project>(bind);
            project.PublishDate = DateTime.Now;
            project.CompanyName = company.CompanyName;
            company.Projects.Add(project);
            this.Context.Projects.Add(project);
            this.Context.SaveChanges();
        }

        public void EditProject(int id, ProjectBm bind)
        {
            Project project = this.GetProject(id);
            project.Title = bind.Title;
            project.Description = bind.Description;
            project.Budjet = bind.Budjet;
            project.SkillsRequired = bind.SkillsRequired;
            this.Context.SaveChanges();
        }

        public void DeleteProject(Project project)
        {
            this.Context.Projects.Remove(project);
            this.Context.SaveChanges();
        }

        public PaginationProjectVm GetPaginationProjectVm(int? page)
        {
            IEnumerable<ProjectVm> pvms = this.GetProjects();
            var pager = new Pager(pvms.Count(), page);

            PaginationProjectVm viewModel = new PaginationProjectVm()
            {
                Items = pvms.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };

            return viewModel;
        }

        public PaginationProjectVm GetEditablePaginationProjectVm(int? page,string username)
        {
            Company company = this.GetCompany(username);
            IEnumerable<ProjectVm> pvms = this.GetMyProjects(company);
            var pager = new Pager(pvms.Count(), page);

            PaginationProjectVm viewModel = new PaginationProjectVm()
            {
                Items = pvms.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };

            return viewModel;
        }
    }
}