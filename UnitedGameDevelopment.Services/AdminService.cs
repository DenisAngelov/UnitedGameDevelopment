namespace UnitedGameDevelopment.Services
{
    using System.Collections.Generic;
    using System.Runtime.Remoting.Contexts;
    using AutoMapper;
    using Models.EntityModels;
    using Models.ViewModels.JobApplications;
    using Models.ViewModels.Projects;
    using Contracts;
    using Data.Contracts;
    using Models.ViewModels.Manage;

    public class AdminService : Service, IAdminService
    {
        public AdminService(IUnitOfWork context)
            :base(context)
        {

        }
        public IEnumerable<ProjectVm> GetProjects()
        {
            IEnumerable<Project> projects = this.Context.Projects.Entities;
            IEnumerable<ProjectVm> cuvm = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectVm>>(projects);
            return cuvm;
        }

        public IEnumerable<JobApplicationVm> GetJobApplications()
        {
            IEnumerable<JobApplication> ja = this.Context.JobApplications.Entities;
            IEnumerable<JobApplicationVm> cuvm = Mapper.Map<IEnumerable<JobApplication>, IEnumerable<JobApplicationVm>>(ja);
            return cuvm;
        }

        public IEnumerable<CompanyUsersVm> GetCompanyUsersVm()
        {
            IEnumerable<Company> companies = this.Context.Companies.Entities;
            IEnumerable<CompanyUsersVm> cuvm = Mapper.Map<IEnumerable<Company>, IEnumerable<CompanyUsersVm>>(companies);
            return cuvm;
        }

        public IEnumerable<FreelancerUserVm> GetFreelancerUsersVm()
        {
            IEnumerable<Freelancer> freelancers = this.Context.Freelancers.Entities;
            IEnumerable<FreelancerUserVm> fuvm = Mapper.Map<IEnumerable<Freelancer>, IEnumerable<FreelancerUserVm>>(freelancers);
            return fuvm;
        }

        public Company GetCompany(int id)
        {
            return this.Context.Companies.FirstOrDefault(comp => comp.Id == id);
        }

        public void DeleteCompany(Company company)
        {
            foreach (var project in company.Projects)
                this.Context.Projects.Remove(project);

            this.Context.Companies.Remove(company);
            this.Context.SaveChanges();
        }

        public Freelancer GetFreelancer(int id)
        {
            return this.Context.Freelancers.FirstOrDefault(fr => fr.Id == id);
        }

        public void DeleteFreelancer(Freelancer freelancer)
        {
            foreach (var jobApp in freelancer.JobApplications)
                this.Context.JobApplications.Remove(jobApp);

            this.Context.Freelancers.Remove(freelancer);
            this.Context.SaveChanges();
        }
    }
}