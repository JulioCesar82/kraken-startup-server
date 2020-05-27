using Microsoft.AspNetCore.Mvc;

namespace KrakenStartup.Web.Controllers
{
    public class HomeController : KrakenStartupControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}