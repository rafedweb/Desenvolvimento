namespace DesafioFortes.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Sobrenome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteID);
            
            CreateTable(
                "dbo.Fornecedor",
                c => new
                    {
                        FornecedorID = c.Int(nullable: false, identity: true),
                        CNPJ = c.Int(nullable: false),
                        RazaoSocial = c.String(nullable: false, maxLength: 150, unicode: false),
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
                        ProdutoID = c.Int(nullable: false),
                        FornecedorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PedidoID)
                .ForeignKey("dbo.Fornecedor", t => t.FornecedorID)
                .ForeignKey("dbo.Produto", t => t.ProdutoID)
                .Index(t => t.ProdutoID)
                .Index(t => t.FornecedorID);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        ProdutoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 250, unicode: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Disponivel = c.Boolean(nullable: false),
                        FornecedorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProdutoID)
                .ForeignKey("dbo.Fornecedor", t => t.FornecedorID)
                .Index(t => t.FornecedorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedido", "ProdutoID", "dbo.Produto");
            DropForeignKey("dbo.Produto", "FornecedorID", "dbo.Fornecedor");
            DropForeignKey("dbo.Pedido", "FornecedorID", "dbo.Fornecedor");
            DropIndex("dbo.Produto", new[] { "FornecedorID" });
            DropIndex("dbo.Pedido", new[] { "FornecedorID" });
            DropIndex("dbo.Pedido", new[] { "ProdutoID" });
            DropTable("dbo.Produto");
            DropTable("dbo.Pedido");
            DropTable("dbo.Fornecedor");
            DropTable("dbo.Cliente");
        }
    }
}
