using CadastroClientes.Data;
using CadastroClientes.Models;
using CadastroClientes.Repositorio.CadastroClienteRepositorio;
using System.Collections.Generic;
using System.Linq;

namespace CadastroClientes.Repositorio.CadastroClienteRepositorio
{
    public class CadastroClienteRepositorio : ICadastroClienteRepositorio
    {
        private readonly BancoContext _bancoContext;

        public CadastroClienteRepositorio(BancoContext bancoContext)
        {
           _bancoContext = bancoContext;  
        }

        public CadastroClienteModel Adicionar(CadastroClienteModel cadastroCliente)
        {
            _bancoContext.CadastroClientes.Add(cadastroCliente);
            _bancoContext.SaveChanges();
            return cadastroCliente;
        }

        public CadastroClienteModel Atualizar(CadastroClienteModel cadastroCliente)
        {
            CadastroClienteModel cadastroClienteDB = ListarPorId(cadastroCliente.Id);

            if (cadastroClienteDB == null) throw new System.Exception("Houve um erro ao Atualizar");

            cadastroClienteDB.Nome = cadastroCliente.Nome;
            cadastroClienteDB.Telefone = cadastroCliente.Telefone;

            _bancoContext.CadastroClientes.Update(cadastroClienteDB);
            _bancoContext.SaveChanges();

            return cadastroClienteDB;

        }

        public List<CadastroClienteModel> BuscarPorTodos()
        {
            return _bancoContext.CadastroClientes.ToList();
        }

        public CadastroClienteModel ListarPorId(int id)
        {
            return _bancoContext.CadastroClientes.FirstOrDefault(x => x.Id == id);
        }
    }
}
