using FichaTecnica.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichaTecnica.Repositorio.EF
{
    public class BaseDeDados : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Permissao> Permissao { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<LinkFork> LinkFork { get; set; }
        public DbSet<Membro> Membro { get; set; }
        public DbSet<Cargo> Cargo { get; set; }

        public BaseDeDados() : base("FICHA_TECNICA_RENAN")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new CargoMap());
            modelBuilder.Configurations.Add(new ComentarioMap());
            modelBuilder.Configurations.Add(new MembroMap());
            modelBuilder.Configurations.Add(new PermissaoMap());
            modelBuilder.Configurations.Add(new ProjetoMap());
            modelBuilder.Configurations.Add(new LinkForkMap());
            base.OnModelCreating(modelBuilder);
        }
    }

    class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");
            HasKey(p => p.Id);

            Property(p => p.Senha).IsRequired().HasMaxLength(200);
            Property(p => p.Email).IsRequired().HasMaxLength(255);
            Property(p => p.Senha).IsRequired().HasMaxLength(200);
            Property(p => p.Nome).IsRequired().HasMaxLength(120);
            HasRequired(p => p.Permissao).WithMany().HasForeignKey(x => x.IdPermissao);
        }
    }

    class PermissaoMap : EntityTypeConfiguration<Permissao>
    {
        public PermissaoMap()
        {
            ToTable("Permissao");
            HasKey(p => p.Id);

            Property(p => p.Descricao).IsRequired().HasMaxLength(120);
        }
    }

    class LinkForkMap : EntityTypeConfiguration<LinkFork>
    {
        public LinkForkMap()
        {
            ToTable("LinkFork");
            HasKey(p => p.Id);

            HasRequired(p => p.Projeto).WithMany().HasForeignKey(x => x.IdProjeto);
            HasRequired(p => p.Membro).WithMany().HasForeignKey(x => x.IdMembro);
            Property(p => p.URL).IsRequired().HasMaxLength(500);
        }
    }

    class ComentarioMap : EntityTypeConfiguration<Comentario>
    {
        public ComentarioMap()
        {
            ToTable("Comentario");
            HasKey(p => p.Id);

            Property(p => p.Assunto).IsRequired().HasMaxLength(500);
            Property(p => p.Texto).IsRequired().HasMaxLength(1000);
            Property(p => p.Tipo).IsRequired();
            Property(p => p.DataCriacao).IsRequired();
            HasRequired(p => p.Usuario).WithMany().HasForeignKey(x => x.IdUsuario);
            HasRequired(p => p.Projeto).WithMany().HasForeignKey(x => x.IdProjeto);
        }
    }

    class ProjetoMap : EntityTypeConfiguration<Projeto>
    {
        public ProjetoMap()
        {
            ToTable("Projeto");
            HasKey(p => p.Id);

            Property(p => p.Nome).IsRequired().HasMaxLength(500);
            Property(p => p.DataInicio).IsRequired();
            Property(p => p.Descricao).IsRequired().HasMaxLength(8000);
            HasRequired(p => p.Usuario).WithMany().HasForeignKey(x => x.IdUsuario);
        }
    }

    class MembroMap : EntityTypeConfiguration<Membro>
    {
        public MembroMap()
        {
            ToTable("Membro");
            HasKey(p => p.Id);

            Property(p => p.Nome).IsRequired().HasMaxLength(500);
            Property(p => p.Email).IsRequired().HasMaxLength(500);
            Property(p => p.DataDeNascimento).IsRequired();
            Property(p => p.Telefone).IsOptional().HasMaxLength(18);
            Property(p => p.Foto).IsOptional().HasMaxLength(500);
            HasRequired(p => p.Cargo).WithMany().HasForeignKey(x => x.IdCargo);
            Property(p => p.DataCriacao).IsRequired();
            HasMany(u => u.Projetos).WithMany(p => p.Membros)
                .Map(m => {
                    m.ToTable("Membro_Projeto");
                    m.MapLeftKey("IdMembro");
                    m.MapRightKey("IdProjeto");
                });
        }
    }

    class CargoMap : EntityTypeConfiguration<Cargo>
    {
        public CargoMap()
        {
            ToTable("Cargo");
            HasKey(p => p.Id);

            Property(p => p.Descricao).IsRequired().HasMaxLength(500);
        }
    }
}

