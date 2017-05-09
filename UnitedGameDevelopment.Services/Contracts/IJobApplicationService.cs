namespace UnitedGameDevelopment.Services.Contracts
{
    using System.Collections.Generic;
    using Models.EntityModels;
    using Models.ViewModels.JobApplications;
    using Models.BindingModels;
    using Models.ViewModels.Pagination;

    public interface IJobApplicationService
    {
        Freelancer GetFreelancer(string username);
        JobApplication GetJobApplication(int id);
        JobApplicationVm GetJobApplicationVm(int id);
        IEnumerable<JobApplicationVm> GetJobApplications();
        IEnumerable<JobApplicationVm> GetMyJobApplications(Freelancer freelancer);
        void CreateJobApplication(JobApplicationBm bind, Freelancer freelancer);
        void EditJobApplication(int id, JobApplicationBm bind);
        void DeleteApplication(JobApplication jobApp);
        PaginationJobApplicationVm GetPaginationApplicationVm(int? page);
        PaginationJobApplicationVm GetEditablePaginationApplicationVm(int? page, string username);
    }
}