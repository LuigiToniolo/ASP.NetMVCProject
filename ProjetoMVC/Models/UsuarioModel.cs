using Microsoft.AspNetCore.Identity;
using ProjetoMVC.Enums;
using System;

namespace ProjetoMVC.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public PerfilEnum Perfil { get; set; }
        public string Senha { get; set; }
        // Ver quando o usuário foi cadastrado e alterado no sistema
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualização { get; set; } // O "?" significa que esse campo PODE ser nulo, ou seja, não é necessário
    }
}
