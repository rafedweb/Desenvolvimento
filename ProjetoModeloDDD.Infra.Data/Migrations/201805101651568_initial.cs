namespace ProjetoModeloDDD.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fornecedor",
                c => new
                    {
                        FornecedorID = c.Int(nullable: false, identity: true),
                        RazaoSocial = c.String(nullable: false, maxLength: 150, unicode: false),
                        CNPJ = c.Int(nullable: false),
                        UF = c.String(maxLength: 100, unicode: false),
                        EmailContato = c.String(nullable: false, maxLength: 100, unicode: false),
                        NomeContato = c.String(maxLength: 100, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FornecedorID);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        PedidoID = c.Int(nullable: false, identity: true),
                        DataPedido = c.DateTime(nullable: false),
                        ValorTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantidadeProdutos = c.Int(nullable: false),
                        FornecedorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PedidoID)
                .ForeignKey("dbo.Fornecedor", t => t.FornecedorID)
                .Index(t => t.FornecedorID);
            
            AddColumn("dbo.Produto", "FornecedorID", c => c.Int(nullable: false));
            AddColumn("dbo.Produto", "Pedido_PedidoID", c => c.Int());
            CreateIndex("dbo.Produto", "FornecedorID");
            CreateIndex("dbo.Produto", "Pedido_PedidoID");
            AddForeignKey("dbo.Produto", "FornecedorID", "dbo.Fornecedor", "FornecedorID");
            AddForeignKey("dbo.Produto", "Pedido_PedidoID", "dbo.Pedido", "PedidoID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", "Pedido_PedidoID", "dbo.Pedido");
            DropForeignKey("dbo.Produto", "FornecedorID", "dbo.Fornecedor");
            DropForeignKey("dbo.Pedido", "FornecedorID", "dbo.Fornecedor");
            DropIndex("dbo.Produto", new[] { "Pedido_PedidoID" });
            DropIndex("dbo.Produto", new[] { "FornecedorID" });
            DropIndex("dbo.Pedido", new[] { "FornecedorID" });
            DropColumn("dbo.Produto", "Pedido_PedidoID");
            DropColumn("dbo.Produto", "FornecedorID");
            DropTable("dbo.Pedido");
            DropTable("dbo.Fornecedor");
        }
    }
}
