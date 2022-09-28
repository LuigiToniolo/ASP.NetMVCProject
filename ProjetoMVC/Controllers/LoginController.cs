using Microsoft.AspNetCore.Mvc;

namespace ProjetoMVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
