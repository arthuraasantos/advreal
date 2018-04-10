using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class EscritorioController : Controller
    {
        public IActionResult Inicio()
        {
            return View();
        }

        public IActionResult Perfil()
        {
            return View();
        }

        public IActionResult Agenda()
        {
            return View();
        }

        public IActionResult Tarefas()
        {
            return View();
        }
    }
}