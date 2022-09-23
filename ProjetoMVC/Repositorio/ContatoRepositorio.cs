using ProjetoMVC.Data;
using ProjetoMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoMVC.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        //Precisamos acessar o bancocontext através de um método, portanto, faremos isso:
        private readonly BancoContext _bancoContext;
        //Temos que injetar o contexto para o ContatoRepositorio
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;   
        }
        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList(); // --> Está carregando tudo que está no banco de dados e está listando
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            //Aqui vamos gravar no banco de dados
            _bancoContext.Contatos.Add(contato);

            //Precisamos commitar a alteração
            _bancoContext.SaveChanges();
            return contato;
        }

    }
}
