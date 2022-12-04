﻿using CadastroClientes.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroClientes.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }
        public DbSet<CadastroClienteModel> CadastroClientes { get; set; }
    }
}
