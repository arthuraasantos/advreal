using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ProcessosController : Controller
    {
        public IActionResult Lista()
        {
            return View();
        }

        public IActionResult Novo()
        {
            return View();
        }
    }
}