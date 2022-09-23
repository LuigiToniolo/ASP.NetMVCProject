using ProjetoMVC.Models;
using System.Collections.Generic;

namespace ProjetoMVC.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel ListarPorId(int id);
        //Listar contatos
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(int id);
    }
}
