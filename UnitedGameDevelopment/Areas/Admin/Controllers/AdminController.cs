namespace UnitedGameDevelopment.Web.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Services.Contracts;
    using Models.ViewModels.JobApplications;
    using Models.ViewModels.Projects;
    using Models.ViewModels.Manage;
    using Models.EntityModels;

    [Authorize(Roles = "Admin")]
    [RouteArea("admin")]
    public class AdminController : Controller
    {
        private IAdminService service;

        public AdminController(IAdminService service)
        {
            this.service = service;
        }

        [HttpGet, Route("home")]
        public ActionResult Index()
        {
            return View();
        }

        #region View

        [HttpGet, Route("projects")]
        public ActionResult Projects()
        {
            IEnumerable<ProjectVm> pvms = this.service.GetProjects();
            return this.View(pvms);
        }

        [HttpGet, Route("job-applications")]
        public ActionResult JobApplications()
        {
            IEnumerable<JobApplicationVm> javms = this.service.GetJobApplications();
            return this.View(javms);
        }

        [HttpGet, Route("company-users")]
        public ActionResult CompanyUsers()
        {
            IEnumerable<CompanyUsersVm> cuvm = this.service.GetCompanyUsersVm();
            return this.View(cuvm);
        }

        [HttpGet, Route("freelancer-users")]
        public ActionResult FreelancerUsers()
        {
            IEnumerable<FreelancerUserVm> fuvm = this.service.GetFreelancerUsersVm();
            return this.View(fuvm);
        }

        #endregion

        #region Delete

        [HttpGet, Route("delete-company/{id}")]
        public ActionResult DeleteCompany(int id)
        {
            try
            {
                Company company = this.service.GetCompany(id);
                return View(company);
            }
            catch (Exception)
            {
                return new HttpNotFoundResult();
            }
        }


        [HttpPost, Route("delete-company/{id}")]
        public ActionResult DeleteCompany(int id, FormCollection collection)
        {
            try
            {
                Company comp = this.service.GetCompany(id);
                this.service.DeleteCompany(comp);
                return RedirectToAction("CompanyUsers");
            }
            catch
            {
                return new HttpNotFoundResult();
            }
        }


        [HttpGet, Route("delete-freelancer/{id}")]
        public ActionResult DeleteFreelancer(int id)
        {
            try
            {
                Freelancer freelancer = this.service.GetFreelancer(id);
                return View(freelancer);
            }
            catch (Exception)
            {
                return new HttpNotFoundResult();
            }
        }

        [HttpPost, Route("delete-freelancer/{id}")]
        public ActionResult DeleteFreelancer(int id, FormCollection collection)
        {
            try
            {
                Freelancer freelancer = this.service.GetFreelancer(id);
                this.service.DeleteFreelancer(freelancer);
                return RedirectToAction("FreelancerUsers");
            }
            catch
            {
                return new HttpNotFoundResult();
            }
        }

        #endregion
    }
}
