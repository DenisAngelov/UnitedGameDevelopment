namespace UnitedGameDevelopment.Web.Controllers
{
    using System.Web.Mvc;
    using System.Web.UI;
    using Services.Contracts;
    using Models.ViewModels.JobApplications;
    using Models.EntityModels;
    using Models.BindingModels;
    using Models.ViewModels.Pagination;

    [RoutePrefix("job-applications"), Authorize(Roles = "Freelancer")]
    public class JobApplicationsController : Controller
    {
        private IJobApplicationService service;

        public JobApplicationsController(IJobApplicationService service)
        {
            this.service = service;
        }

        [HttpGet, Route("index")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("list-applications")]
        [AllowAnonymous]
        [OutputCache(Duration = 10, Location = OutputCacheLocation.Client)]
        public ActionResult JobApplications(int? page)
        {
            PaginationJobApplicationVm pjavm = this.service.GetPaginationApplicationVm(page);
            return this.View(pjavm);
        }

        [HttpGet, Route("application-details/{id}")]
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            JobApplicationVm javm = this.service.GetJobApplicationVm(id);
            return View(javm);
        }

        [HttpGet, Route("my-applications")]
        [OutputCache(Duration = 10, Location = OutputCacheLocation.Client)]
        public ActionResult MyJobApplications(int? page)
        {
            PaginationJobApplicationVm pgavm = this.service.GetEditablePaginationApplicationVm(page, User.Identity.Name);
            return this.View(pgavm);
        }

        [HttpGet, Route("create-application")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("create-application")]
        public ActionResult Create(JobApplicationBm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.CreateJobApplication(bind, this.service.GetFreelancer(User.Identity.Name));
                return RedirectToAction("JobApplications");
            }

            return this.View(bind);
        }

        [HttpGet, Route("edit-application/{id}")]
        public ActionResult Edit(int id)
        {
            JobApplication ja = this.service.GetJobApplication(id);
            return View(ja);
        }

        [HttpPost, Route("edit-application/{id}")]
        public ActionResult Edit(int id, JobApplicationBm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.EditJobApplication(id, bind);
                return RedirectToAction("JobApplications");
            }

            return View(this.service.GetJobApplicationVm(id));
        }

        [HttpGet, Route("delete-application/{id}")]
        public ActionResult Delete(int id)
        {
            JobApplication ja = this.service.GetJobApplication(id);
            return View(ja);
        }

        [HttpPost, Route("delete-application/{id}")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                JobApplication jobApp = this.service.GetJobApplication(id);
                this.service.DeleteApplication(jobApp);
                return RedirectToAction("JobApplications");
            }
            catch
            {
                return View();
            }
        }
    }
}
