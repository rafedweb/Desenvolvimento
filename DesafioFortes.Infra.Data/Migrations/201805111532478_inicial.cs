namespace ProjetoModeloDDD.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produto", "ClienteID", "dbo.Cliente");
            DropIndex("dbo.Produto", new[] { "ClienteID" });
            DropIndex("dbo.Produto", new[] { "Pedido_PedidoID" });
            RenameColumn(table: "dbo.Pedido", name: "Pedido_PedidoID", newName: "ProdutoID");
            CreateIndex("dbo.Pedido", "ProdutoID");
            DropColumn("dbo.Produto", "ClienteID");
            DropColumn("dbo.Produto", "Pedido_PedidoID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produto", "Pedido_PedidoID", c => c.Int());
            AddColumn("dbo.Produto", "ClienteID", c => c.Int(nullable: false));
            DropIndex("dbo.Pedido", new[] { "ProdutoID" });
            RenameColumn(table: "dbo.Pedido", name: "ProdutoID", newName: "Pedido_PedidoID");
            CreateIndex("dbo.Produto", "Pedido_PedidoID");
            CreateIndex("dbo.Produto", "ClienteID");
            AddForeignKey("dbo.Produto", "ClienteID", "dbo.Cliente", "ClienteID");
        }
    }
}
