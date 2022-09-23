using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Models;
using ProjetoMVC.Repositorio;
using System.Collections.Generic;

namespace ProjetoMVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio; 
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();

            return View(contatos);
        }
        public IActionResult CriarContato()
        {
            return View();
        }
        public IActionResult EditarContato()
        {
            return View();
        }
        public IActionResult ApagarConfirmacao()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            //Fazer a insersão desse registro, injetar o IContatoRepositorio de ContatoRepositorio
            _contatoRepositorio.Adicionar(contato);
            return RedirectToAction("Index");
        }

    }
}
