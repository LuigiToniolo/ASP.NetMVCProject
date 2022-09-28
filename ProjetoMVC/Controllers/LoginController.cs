using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Models;
using ProjetoMVC.Repositorio;
using System;

namespace ProjetoMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        //Fazer um método que irá receber os dados do login e fazer a autenticação e redirecionar

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    //Fazendo a primeira validação:

                    if(usuario != null)
                    {
                        // --> Fazer agora se a senha que o usuário colocou confere com a senha cadastrada pelo usuário na hora de cadastrar:

                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            return RedirectToAction("Index", "Home"); // --> quando clica no botão, não vai fazer nada de validação ou autenticação
                        }

                        TempData["MensagemErro"] = $"A senha do usuário não confere!";

                    }

                    TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Por favor tente novamente.";
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
