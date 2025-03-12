using Microsoft.AspNetCore.Mvc;

namespace RotatingBendingTestBench.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
