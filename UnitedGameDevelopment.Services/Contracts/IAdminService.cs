namespace UnitedGameDevelopment.Services.Contracts
{
    using System.Collections.Generic;
    using Models.EntityModels;
    using Models.ViewModels.JobApplications;
    using Models.ViewModels.Projects;
    using Models.ViewModels.Manage;

    public interface IAdminService
    {
        IEnumerable<ProjectVm> GetProjects();
        IEnumerable<JobApplicationVm> GetJobApplications();
        IEnumerable<CompanyUsersVm> GetCompanyUsersVm();
        IEnumerable<FreelancerUserVm> GetFreelancerUsersVm();
        Company GetCompany(int id);
        void DeleteCompany(Company company);
        Freelancer GetFreelancer(int id);
        void DeleteFreelancer(Freelancer freelancer);

    }
}