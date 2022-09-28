using System.ComponentModel.DataAnnotations;

namespace ProjetoMVC.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o nome do Login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite a senha")]
        public string Senha { get; set; }
    }
}
