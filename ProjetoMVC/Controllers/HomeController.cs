using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMVC.Controllers
{
    public class HomeController : Controller //Home controller é uma classe que herda de controller
    {
        //Temos os três métodos: index, privacidade e erro.

        public IActionResult Index()
        {
            //Iremos pegar os dados que criamos na model (Nome e Email), instanciando os dados abaixo:
            HomeModel home = new HomeModel();

            home.Nome = "Luigi Toniolo";
            home.Email = "luigibtoniolo@gmail.com";

            return View(home);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
