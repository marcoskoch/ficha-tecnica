namespace FichaTecnica.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEstadoAoComentario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comentario", "Estado", c => c.Int(nullable: false, defaultValue: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comentario", "Estado");
        }
    }
}
