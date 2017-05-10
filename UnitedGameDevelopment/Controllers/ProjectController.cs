namespace UnitedGameDevelopment.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Web.UI;
    using Models.ViewModels.Projects;
    using Services.Contracts;
    using Models.BindingModels;
    using Models.EntityModels;
    using Models.ViewModels.Pagination;

    [RoutePrefix("projects")]
    [Authorize(Roles = "Company, Admin")]
    public class ProjectController : Controller
    {
        private IProjectService service;

        public ProjectController(IProjectService service)
        {
            this.service = service;
        }

        [HttpGet, Route("index")]
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet, Route("list-projects")]
        [OutputCache(Duration = 10, Location = OutputCacheLocation.Client)]
        [AllowAnonymous]
        public ActionResult Projects(int? page)
        {
            PaginationProjectVm ppvm = this.service.GetPaginationProjectVm(page);
            return this.View(ppvm);
        }

        [HttpGet, Route("details/{id}")]
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            ProjectVm vm = this.service.GetProjectVm(id);
            return View(vm);
        }


        [HttpGet, Route("my-projects")]
        [OutputCache(Duration = 10, Location = OutputCacheLocation.Client)]
        public ActionResult MyProjects(int? page)
        {
            PaginationProjectVm ppvm = this.service.GetEditablePaginationProjectVm(page, User.Identity.Name);
            return this.View(ppvm);
        }


        [HttpGet, Route("create-project")]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost, Route("create-project")]
        public ActionResult Create(ProjectBm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.CreateProject(bind, this.service.GetCompany(User.Identity.Name));
                return this.RedirectToAction("Projects");
            }

            return this.View(bind);

        }

        [HttpGet, Route("edit-project/{id}")]
        public ActionResult Edit(int id)
        {
            try
            {
                Project project = this.service.GetProject(id);
                return View(project);
            }
            catch (Exception)
            {
                return new HttpNotFoundResult();
            }
        }

        [HttpPost, Route("edit-project/{id}")]
        public ActionResult Edit(int id, ProjectBm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.EditProject(id, bind);
                return RedirectToAction("Projects");
            }

            return View(this.service.GetProjectVm(id));
        }

        [HttpGet, Route("delete-project/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Project project = this.service.GetProject(id);
                return View(project);
            }
            catch (Exception)
            {
                return new HttpNotFoundResult();
            }
            
        }

        [HttpPost, Route("delete-project/{id}")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Project project = this.service.GetProject(id);
                this.service.DeleteProject(project);
                return RedirectToAction("Projects");
            }
            catch
            {
                return new HttpNotFoundResult();
            }
        }
    }
}
