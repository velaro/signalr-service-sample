using System.Web.Mvc;

namespace Velaro.ChatService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}