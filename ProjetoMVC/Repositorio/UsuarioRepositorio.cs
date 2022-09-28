using ProjetoMVC.Data;
using ProjetoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoMVC.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        //Precisamos acessar o bancocontext através de um método, portanto, faremos isso:
        private readonly BancoContext _context;
        //Temos que injetar o contexto para o ContatoRepositorio
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            this._context = bancoContext;   
        }
        public UsuarioModel BuscarPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id); // --> vai listar o contato correspondente do ID
        }
        public List<UsuarioModel> BuscarTodos()
        {
            return _context.Usuarios.ToList(); // --> Está carregando tudo que está no banco de dados e está listando
        }
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            //Aqui vamos gravar no banco de dados
            usuario.DataCadastro = DateTime.Now;
            _context.Usuarios.Add(usuario);

            //Precisamos commitar a alteração
            _context.SaveChanges();
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = BuscarPorId(usuario.Id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na atualização dos dados do usuario!");

            usuarioDB.Name = usuario.Name;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualização = DateTime.Now; //Colocar o tempo (data) imediata que foi atualizado!

            _context.Usuarios.Update(usuarioDB);
            _context.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = BuscarPorId(id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na deleção do usuário!");

            _context.Usuarios.Remove(usuarioDB);
            _context.SaveChanges();

            return true;
        }
    }
}
