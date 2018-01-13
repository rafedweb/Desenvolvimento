namespace ProjetoModeloDDD.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        ProdutoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 250, unicode: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Disponivel = c.Boolean(nullable: false),
                        ClienteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProdutoID)
                .ForeignKey("dbo.Cliente", t => t.ClienteID)
                .Index(t => t.ClienteID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", "ClienteID", "dbo.Cliente");
            DropIndex("dbo.Produto", new[] { "ClienteID" });
            DropTable("dbo.Produto");
        }
    }
}
