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
        public IActionResult EditarContato(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id); // --> Precisa também buscar um contato pelo id
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            _contatoRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            //Fazer a insersão desse registro, injetar o IContatoRepositorio de ContatoRepositorio
            _contatoRepositorio.Adicionar(contato);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            //Fazer a insersão desse registro, injetar o IContatoRepositorio de ContatoRepositorio
            _contatoRepositorio.Atualizar(contato);
            return RedirectToAction("Index");
        }

    }
}
