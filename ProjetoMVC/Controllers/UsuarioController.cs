using Microsoft.AspNetCore.Mvc;

namespace ProjetoMVC.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
