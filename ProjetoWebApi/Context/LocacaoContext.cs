using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoWebApi.Models;
using ProjetoWebApi;

namespace ProjetoWebApi.Context
{
    public class LocacaoContext : DbContext
    {
        public LocacaoContext(){}
        public LocacaoContext(DbContextOptions<LocacaoContext> options) : base(options)
        {
            //Todo: Configurar migration
            //ToDo: Executar os comandos do migratin
            //ToDo: Inserir, Atualizar, Deletar e Selecionar
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<CarroModel> Carros { get; set; }
        public DbSet<MarcaModel> Marcas { get; set; }
        
        
    }
}