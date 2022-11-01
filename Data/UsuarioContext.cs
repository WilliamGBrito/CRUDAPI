using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUDAPI.Data
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder b){
            
            var usuario = b.Entity<Usuario>();
            usuario.HasKey(x => x.Id);
            usuario.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            usuario.Property(x => x.Nome).HasColumnName("nome").IsRequired().HasMaxLength(30);
            usuario.Property(x => x.DataNascimento).HasColumnName("Data_de_Nascimento");
        }
    }
}