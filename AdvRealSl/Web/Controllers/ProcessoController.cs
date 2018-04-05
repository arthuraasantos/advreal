using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ProcessoController : Controller
    {
        public IActionResult Lista()
        {
            return View();
        }

        public IActionResult Novo()
        {
            return View();
        }

        public IActionResult Detalhe()
        {
            return View();
        }
    }
}