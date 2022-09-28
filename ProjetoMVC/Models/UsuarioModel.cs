using Microsoft.AspNetCore.Identity;
using ProjetoMVC.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMVC.Models
{
    public class UsuarioModel
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
        public string Senha { get; set; }
        [Required(ErrorMessage ="Digite a senha do usuário")]
        // Ver quando o usuário foi cadastrado e alterado no sistema
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualização { get; set; } // O "?" significa que esse campo PODE ser nulo, ou seja, não é necessário
        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
    }
}
