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
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Fornecedor> Fornecedores { get; set; }

        public DbSet<Modelos> Modelos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

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

            modelBuilder.Entity<Modelos>()
                    .HasData(
                        new Modelos { Id = 1, Id_fornecedor = 2, Nome = "Sapatênis", CodigoRef = "a321", Cor = "Rosa", Tamanho = 34 }
                    );

            modelBuilder.Entity<Fornecedor>()
                    .HasData(
                        new Fornecedor { Id = 1, Nome = "Victor Augusto", CNPJ = "00000000000000", Endereco = "Rua Victor Augusto, 230" }
                    );

            modelBuilder.Entity<Fornecedor>()
                    .Property(p => p.CNPJ)
                    .HasMaxLength(11)
                    .IsRequired();

            modelBuilder.Entity<Cliente>()
                   .Property(p => p.Nome)
                   .HasMaxLength(200);

            modelBuilder.Entity<Cliente>()
                   .Property(p => p.Endereco)
                   .HasMaxLength(200);

            modelBuilder.Entity<Cliente>()
                    .Property(p => p.Idade)
                    .HasMaxLength(3);

            modelBuilder.Entity<Cliente>()
                    .HasData(
                        new Cliente {  Id = 1, Nome = "José", Cpf = "12547852", Endereco = "Rua Dr Anão", Idade = 21}
                    );
        }
    }
}
