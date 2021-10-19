using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto_Loja_Sapatos.Models;

namespace Projeto_Loja_Sapatos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        {

        }

        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fornecedor>()
                   .Property(p => p.Nome)
                   .HasMaxLength(200);

            modelBuilder.Entity<Fornecedor>()
                   .Property(p => p.Endereco)
                   .HasMaxLength(200);

            modelBuilder.Entity<Fornecedor>()
                .Property(p => p.CNPJ)
                .HasMaxLength(14)
                .IsRequired();
        }
    }
}
