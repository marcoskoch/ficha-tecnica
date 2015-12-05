namespace FichaTecnica.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembroNoComentario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comentario", "IdMembro", c => c.Int(nullable: false));
            CreateIndex("dbo.Comentario", "IdMembro");
            AddForeignKey("dbo.Comentario", "IdMembro", "dbo.Membro", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentario", "IdMembro", "dbo.Membro");
            DropIndex("dbo.Comentario", new[] { "IdMembro" });
            DropColumn("dbo.Comentario", "IdMembro");
        }
    }
}
