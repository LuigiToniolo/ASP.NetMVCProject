using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Models;
using ProjetoMVC.Repositorio;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ProjetoMVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();

            return View(usuarios);
        }
        public IActionResult CriarUsuario()
        {
            return View();
        }

        public IActionResult EditarUsuario(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.BuscarPorId(id);
            return View(usuario);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.BuscarPorId(id); // --> Precisa também buscar um contato pelo id
            return View(usuario);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                _usuarioRepositorio.Apagar(id);
                TempData["MensagemSucesso"] = "Usuário deletado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos deletar o usuário, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult CriarUsuario(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Fazer a insersão desse registro, injetar o IContatoRepositorio de ContatoRepositorio
                    usuario = _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                // Agora iremos fazer um tratamento de erro com "try" e "catch"

                return View(usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar o usuario, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult EditarUsuario(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                UsuarioModel usuario = null; // --> Iremos instanciar essa variável pois a usuarioModel e a usuarioSemSenhaModel tem atributos diferentes

                //Fazer a insersão desse registro, injetar o IContatoRepositorio de ContatoRepositorio
                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Name = usuarioSemSenhaModel.Name,
                        Login = usuarioSemSenhaModel.Login,
                        Email = usuarioSemSenhaModel.Email,
                        Perfil = usuarioSemSenhaModel.Perfil,
                    };

                    usuario = _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuário editado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos editar o usuário, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
