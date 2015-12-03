namespace FichaTecnica.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cargo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comentario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Assunto = c.String(nullable: false, maxLength: 500),
                        Texto = c.String(nullable: false, maxLength: 1000),
                        Tipo = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        IdProjeto = c.Int(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projeto", t => t.IdProjeto, cascadeDelete: false)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario, cascadeDelete: false)
                .Index(t => t.IdProjeto)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.Projeto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 500),
                        DataInicio = c.DateTime(nullable: false),
                        Descricao = c.String(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario, cascadeDelete: false)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.Membro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 500),
                        Email = c.String(nullable: false, maxLength: 500),
                        DataDeNascimento = c.DateTime(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        Telefone = c.String(maxLength: 18),
                        Foto = c.String(maxLength: 500),
                        IdCargo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cargo", t => t.IdCargo, cascadeDelete: false)
                .Index(t => t.IdCargo);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Senha = c.String(nullable: false, maxLength: 200),
                        Email = c.String(nullable: false, maxLength: 255),
                        Nome = c.String(nullable: false, maxLength: 120),
                        IdPermissao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Permissao", t => t.IdPermissao, cascadeDelete: false)
                .Index(t => t.IdPermissao);
            
            CreateTable(
                "dbo.Permissao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 120),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LinkFork",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdProjeto = c.Int(nullable: false),
                        IdMembro = c.Int(nullable: false),
                        URL = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.IdProjeto);
            
            CreateTable(
                "dbo.Membro_Projeto",
                c => new
                    {
                        IdMembro = c.Int(nullable: false),
                        IdProjeto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdMembro, t.IdProjeto })
                .ForeignKey("dbo.Membro", t => t.IdMembro, cascadeDelete: false)
                .ForeignKey("dbo.Projeto", t => t.IdProjeto, cascadeDelete: false)
                .Index(t => t.IdMembro)
                .Index(t => t.IdProjeto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentario", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Comentario", "IdProjeto", "dbo.Projeto");
            DropForeignKey("dbo.Projeto", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "IdPermissao", "dbo.Permissao");
            DropForeignKey("dbo.Membro_Projeto", "IdProjeto", "dbo.Projeto");
            DropForeignKey("dbo.Membro_Projeto", "IdMembro", "dbo.Membro");
            DropForeignKey("dbo.Membro", "IdCargo", "dbo.Cargo");
            DropIndex("dbo.Membro_Projeto", new[] { "IdProjeto" });
            DropIndex("dbo.Membro_Projeto", new[] { "IdMembro" });
            DropIndex("dbo.Usuario", new[] { "IdPermissao" });
            DropIndex("dbo.Membro", new[] { "IdCargo" });
            DropIndex("dbo.Projeto", new[] { "IdUsuario" });
            DropIndex("dbo.Comentario", new[] { "IdUsuario" });
            DropIndex("dbo.Comentario", new[] { "IdProjeto" });
            DropTable("dbo.Membro_Projeto");
            DropTable("dbo.LinkFork");
            DropTable("dbo.Permissao");
            DropTable("dbo.Usuario");
            DropTable("dbo.Membro");
            DropTable("dbo.Projeto");
            DropTable("dbo.Comentario");
            DropTable("dbo.Cargo");
        }
    }
}
