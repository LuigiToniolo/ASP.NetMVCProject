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
            try
            {
                _contatoRepositorio.Apagar(id);
                TempData["MensagemSucesso"] = "Contato deletado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos deletar o contato, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult CriarContato(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Fazer a insersão desse registro, injetar o IContatoRepositorio de ContatoRepositorio
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                // Agora iremos fazer um tratamento de erro com "try" e "catch"

                return View(contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar o contato, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                //Fazer a insersão desse registro, injetar o IContatoRepositorio de ContatoRepositorio
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato editado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("EditarContato", contato);
            }
            catch(System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos editar o contato, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
