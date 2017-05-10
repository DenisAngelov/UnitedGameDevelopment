namespace UnitedGameDevelopment.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Models.EntityModels;
    using Contracts;
    using Models.ViewModels.JobApplications;
    using Models.BindingModels;
    using Data.Contracts;
    using Models.ViewModels.Pagination;

    public class JobApplicationService : Service, IJobApplicationService
    {
        public JobApplicationService(IUnitOfWork context)
            :base(context)
        {
            
        }

        public Freelancer GetFreelancer(string username)
        {
            return this.Context.Freelancers.FirstOrDefault(au => au.User.UserName == username);
        }

        public JobApplication GetJobApplication(int id)
        {
            return this.Context.JobApplications.FirstOrDefault(ja => ja.Id == id);
        }

        public JobApplicationVm GetJobApplicationVm(int id)
        {
            JobApplication ja = this.GetJobApplication(id);
            JobApplicationVm javm = Mapper.Map<JobApplication, JobApplicationVm>(ja);
            return javm;
        }

        public IEnumerable<JobApplicationVm> GetJobApplications()
        {
            IEnumerable<JobApplication> jobApplications = this.Context.JobApplications.Entities;
            IEnumerable<JobApplicationVm> vm =
                Mapper.Map<IEnumerable<JobApplication>, IEnumerable<JobApplicationVm>>(jobApplications);
            return vm;
        }

        public IEnumerable<JobApplicationVm> GetMyJobApplications(Freelancer freelancer)
        {
            IEnumerable<JobApplication> ja = freelancer.JobApplications;
            IEnumerable<JobApplicationVm> javm =
                Mapper.Map<IEnumerable<JobApplication>, IEnumerable<JobApplicationVm>>(ja);
            return javm;
        }

        public void CreateJobApplication(JobApplicationBm bind, Freelancer freelancer)
        {
            JobApplication ja = Mapper.Map<JobApplicationBm, JobApplication>(bind);
            ja.Freelancer = freelancer;
            ja.PublishDate = DateTime.Now;
            freelancer.JobApplications.Add(ja);
            this.Context.JobApplications.Add(ja);
            this.Context.SaveChanges();
        }

        public void EditJobApplication(int id, JobApplicationBm bind)
        {
            JobApplication ja = this.GetJobApplication(id);
            ja.Title = bind.Title;
            ja.Description = bind.Description;
            ja.SalaryPerHour = bind.SalaryPerHour;
            ja.SkillsAcquired = bind.SkillsAcquired;
            this.Context.SaveChanges();
        }

        public void DeleteApplication(JobApplication jobApp)
        {
            this.Context.JobApplications.Remove(jobApp);
            this.Context.SaveChanges();
        }


        public PaginationJobApplicationVm GetPaginationApplicationVm(int? page)
        {
            IEnumerable<JobApplicationVm> pvms = this.GetJobApplications();
            var pager = new Pager(pvms.Count(), page);

            PaginationJobApplicationVm viewModel = new PaginationJobApplicationVm()
            {
                Items = pvms.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };

            return viewModel;
        }

        public PaginationJobApplicationVm GetEditablePaginationApplicationVm(int? page, string username)
        {
            Freelancer freelancer = this.GetFreelancer(username);
            IEnumerable<JobApplicationVm> pvms = this.GetMyJobApplications(freelancer);
            var pager = new Pager(pvms.Count(), page);

            PaginationJobApplicationVm viewModel = new PaginationJobApplicationVm()
            {
                Items = pvms.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };

            return viewModel;
        }
    }
}