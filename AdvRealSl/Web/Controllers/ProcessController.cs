using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ProcessController : Controller
    {
        public IActionResult Start()
        {
            return View();
        }

        public IActionResult New()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}