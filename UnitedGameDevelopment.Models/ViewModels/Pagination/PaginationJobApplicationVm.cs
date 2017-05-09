namespace UnitedGameDevelopment.Models.ViewModels.Pagination
{
    using System.Collections.Generic;
    using JobApplications;

    public class PaginationJobApplicationVm
    {
        public IEnumerable<JobApplicationVm> Items { get; set; }
        public Pager Pager { get; set; }
    }
}