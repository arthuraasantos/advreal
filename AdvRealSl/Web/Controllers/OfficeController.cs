using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize]
    public class OfficeController : Controller
    {
        public IActionResult Start()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Calendar()
        {
            return View();
        }

        public IActionResult Tasks()
        {
            return View();
        }
    }
}