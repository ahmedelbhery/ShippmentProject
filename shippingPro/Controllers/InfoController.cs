using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class InfoController : Controller
    {
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}
