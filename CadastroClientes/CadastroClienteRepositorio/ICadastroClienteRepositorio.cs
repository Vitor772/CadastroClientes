using CadastroClientes.Models;
using System.Collections.Generic;

namespace CadastroClientes.Repositorio.CadastroClienteRepositorio
{
    public interface ICadastroClienteRepositorio
    {
        CadastroClienteModel ListarPorId(int id);
        List<CadastroClienteModel> BuscarPorTodos();
        CadastroClienteModel Adicionar(CadastroClienteModel cadastroCliente);
        CadastroClienteModel Atualizar(CadastroClienteModel cadastroCliente);
        bool Apagar(int id);
    }
}
