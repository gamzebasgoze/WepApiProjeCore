using Microsoft.AspNetCore.Mvc;

namespace WepApiProjeCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
