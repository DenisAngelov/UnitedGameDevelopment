namespace UnitedGameDevelopment.Models.ViewModels.Pagination
{
    using System.Collections.Generic;
    using Projects;

    public class PaginationProjectVm
    {
        public IEnumerable<ProjectVm> Items { get; set; }
        public Pager Pager { get; set; }
    }
}