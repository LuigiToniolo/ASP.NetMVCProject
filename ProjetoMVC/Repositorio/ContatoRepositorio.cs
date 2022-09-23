using ProjetoMVC.Data;
using ProjetoMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoMVC.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        //Precisamos acessar o bancocontext através de um método, portanto, faremos isso:
        private readonly BancoContext _context;
        //Temos que injetar o contexto para o ContatoRepositorio
        public ContatoRepositorio(BancoContext bancoContext)
        {
            this._context = bancoContext;   
        }
        public ContatoModel ListarPorId(int id)
        {
            return _context.Contatos.FirstOrDefault(x => x.Id == id); // --> vai listar o contato correspondente do ID
        }
        public List<ContatoModel> BuscarTodos()
        {
            return _context.Contatos.ToList(); // --> Está carregando tudo que está no banco de dados e está listando
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            //Aqui vamos gravar no banco de dados
            _context.Contatos.Add(contato);

            //Precisamos commitar a alteração
            _context.SaveChanges();
            return contato;
        }
        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPorId(contato.Id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na atualização dos dados do contato");

            contatoDB.Name = contato.Name;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _context.Contatos.Update(contatoDB);
            _context.SaveChanges();

            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListarPorId(id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na deleção do contato");

            _context.Contatos.Remove(contatoDB);
            _context.SaveChanges();

            return true;
        }
    }
}
