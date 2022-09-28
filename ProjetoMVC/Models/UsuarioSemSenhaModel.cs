using Microsoft.AspNetCore.Identity;
using ProjetoMVC.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMVC.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do Usuário!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Digite o nome do Login!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o E-mail do Usuário!")]
        [EmailAddress(ErrorMessage = "O E-mail informado não é válido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Selecione o Perfil do Usuário!")]
        public PerfilEnum? Perfil { get; set; }
        // Ver quando o usuário foi cadastrado e alterado no sistema
    }
}
