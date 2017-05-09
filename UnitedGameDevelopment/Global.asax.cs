namespace UnitedGameDevelopment.Web
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using AutoMapper;
    using Models.EntityModels;
    using Models.ViewModels.Projects;
    using Models.ViewModels.JobApplications;
    using Models.BindingModels;
    using Models.ViewModels.Manage;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            this.ConfigureMappings();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

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
    }
}
