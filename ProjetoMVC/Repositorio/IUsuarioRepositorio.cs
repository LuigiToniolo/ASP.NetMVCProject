using ProjetoMVC.Models;
using System.Collections.Generic;

namespace ProjetoMVC.Repositorio
{
    public interface IUsuarioRepositorio
    {
        //Temos todos os retornos (métodos)
        //Listar usuario
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        bool Apagar(int id);
        UsuarioModel BuscarPorId(int id);
    }
}
