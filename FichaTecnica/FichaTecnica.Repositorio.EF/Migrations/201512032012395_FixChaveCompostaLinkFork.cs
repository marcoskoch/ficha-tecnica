namespace FichaTecnica.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixChaveCompostaLinkFork : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.LinkFork");
            AlterColumn("dbo.Comentario", "DataCriacao", c => c.DateTime(nullable: false));
            AlterColumn("dbo.LinkFork", "IdProjeto", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.LinkFork", "Id");
            CreateIndex("dbo.LinkFork", "IdMembro");
            CreateIndex("dbo.LinkFork", "IdProjeto");
            AddForeignKey("dbo.LinkFork", "IdMembro", "dbo.Membro", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LinkFork", "IdProjeto", "dbo.Projeto", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LinkFork", "IdProjeto", "dbo.Projeto");
            DropForeignKey("dbo.LinkFork", "IdMembro", "dbo.Membro");
            DropIndex("dbo.LinkFork", new[] { "IdProjeto" });
            DropIndex("dbo.LinkFork", new[] { "IdMembro" });
            DropPrimaryKey("dbo.LinkFork");
            AlterColumn("dbo.LinkFork", "IdProjeto", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Comentario", "DataCriacao", c => c.Int(nullable: false));
            DropColumn("dbo.LinkFork", "Id");
            AddPrimaryKey("dbo.LinkFork", "IdProjeto");
        }
    }
}
