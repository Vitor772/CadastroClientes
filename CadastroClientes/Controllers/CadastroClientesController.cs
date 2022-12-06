using CadastroClientes.Models;
using CadastroClientes.Repositorio.CadastroClienteRepositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CadastroClientes.Controllers
{
    public class CadastroClientesController : Controller
    {
        private readonly ICadastroClienteRepositorio _cadastroClienteRepositorio; 
        
        public CadastroClientesController(ICadastroClienteRepositorio cadastroClienteRepositorio)
        {
            _cadastroClienteRepositorio = cadastroClienteRepositorio;
        }


        public IActionResult Index()
        {
            List<CadastroClienteModel> cadastroCliente = _cadastroClienteRepositorio.BuscarPorTodos();

            return View(cadastroCliente);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(CadastroClienteModel cadastroCliente)
        {
            _cadastroClienteRepositorio.Adicionar(cadastroCliente);
            return View("Index");
        }

        public IActionResult Editar(int id)
        {
            CadastroClienteModel cadastroCliente = _cadastroClienteRepositorio.ListarPorId(id);
            return View(cadastroCliente);
        
        }
        public IActionResult Apagar(int id)
        {
            _cadastroClienteRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            CadastroClienteModel cadastroCliente = _cadastroClienteRepositorio.ListarPorId(id);
            return View(cadastroCliente);
        }


        [HttpPost]
        public IActionResult Alterar(CadastroClienteModel cadastroCliente)
        {
             _cadastroClienteRepositorio.Atualizar(cadastroCliente);
             return RedirectToAction("Index");
            
        }
    }
}
