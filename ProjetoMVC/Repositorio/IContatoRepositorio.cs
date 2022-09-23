using ProjetoMVC.Models;
using System.Collections.Generic;

namespace ProjetoMVC.Repositorio
{
    public interface IContatoRepositorio
    {
        //Listar contatos
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);
    }
}
