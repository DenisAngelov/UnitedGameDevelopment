namespace UnitedGameDevelopment.Services.Contracts
{
    using System.Collections.Generic;
    using Models.ViewModels.Projects;
    using Models.BindingModels;
    using Models.EntityModels;
    using Models.ViewModels.Pagination;

    public interface IProjectService
    {
        Company GetCompany(string username);
        ProjectVm GetProjectVm(int id);
        Project GetProject(int id);
        IEnumerable<ProjectVm> GetProjects();
        IEnumerable<ProjectVm> GetMyProjects(Company company);
        void CreateProject(ProjectBm bind, Company company);
        void EditProject(int id, ProjectBm bind);
        void DeleteProject(Project project);
        PaginationProjectVm GetPaginationProjectVm(int? page);
        PaginationProjectVm GetEditablePaginationProjectVm(int? page, string username);
    }
}