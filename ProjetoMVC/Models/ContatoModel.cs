using System.ComponentModel.DataAnnotations;

namespace ProjetoMVC.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Digite o nome do contato!")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Digite o e-mail do contato!")]
        [EmailAddress(ErrorMessage ="O E-mail informado não é válido!")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Digite o número de celular do contato!")]
        [Phone(ErrorMessage ="O celular informado não é válido!")]
        public string Celular { get; set; }
        
    }
}
