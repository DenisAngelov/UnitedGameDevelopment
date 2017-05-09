namespace UnitedGameDevelopment.Web.Controllers
{
    using System.Web.Mvc;

    [RoutePrefix("home")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("index")]
        public ActionResult Index()
        {
            return View();
        }
    }
}