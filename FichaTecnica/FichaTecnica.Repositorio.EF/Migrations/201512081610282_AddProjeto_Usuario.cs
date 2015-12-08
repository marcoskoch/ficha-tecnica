namespace FichaTecnica.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjeto_Usuario : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projeto", "IdUsuario", "dbo.Usuario");
            DropIndex("dbo.Projeto", new[] { "IdUsuario" });
            CreateTable(
                "dbo.Projeto_Usuario",
                c => new
                    {
                        IdProjeto = c.Int(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdProjeto, t.IdUsuario })
                .ForeignKey("dbo.Projeto", t => t.IdProjeto, cascadeDelete: false)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario, cascadeDelete: false)
                .Index(t => t.IdProjeto)
                .Index(t => t.IdUsuario);
            
            DropColumn("dbo.Projeto", "IdUsuario");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projeto", "IdUsuario", c => c.Int(nullable: false));
            DropForeignKey("dbo.Projeto_Usuario", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Projeto_Usuario", "IdProjeto", "dbo.Projeto");
            DropIndex("dbo.Projeto_Usuario", new[] { "IdUsuario" });
            DropIndex("dbo.Projeto_Usuario", new[] { "IdProjeto" });
            DropTable("dbo.Projeto_Usuario");
            CreateIndex("dbo.Projeto", "IdUsuario");
            AddForeignKey("dbo.Projeto", "IdUsuario", "dbo.Usuario", "Id", cascadeDelete: false);
        }
    }
}
