using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CustomerController : Controller
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