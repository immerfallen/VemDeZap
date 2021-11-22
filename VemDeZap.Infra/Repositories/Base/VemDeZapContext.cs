using Microsoft.EntityFrameworkCore;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;
using VemDeZap.Domain.Entities;
using VemDeZap.Infra.Repositories.Map;

namespace VemDeZap.Infra.Repositories.Base
{
    public partial class VemDeZapContext : DbContext
    {
        //Criar as tabelas
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Campanha> Campanha { get; set; }
        public DbSet<Envio> Envio { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Contato> Contato { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=VemDeZap;Uid=root;Pwd=158797;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                
            modelBuilder.Ignore<Notification>();
            modelBuilder.ApplyConfiguration(new MapUsuario());
            modelBuilder.ApplyConfiguration(new MapGrupo());
            modelBuilder.ApplyConfiguration(new MapContato());

            base.OnModelCreating(modelBuilder);
            
        }

    }
}
