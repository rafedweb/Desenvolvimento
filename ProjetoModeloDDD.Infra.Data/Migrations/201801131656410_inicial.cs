namespace ProjetoModeloDDD.Infra.Data.Migrations
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
                        Nome = c.String(maxLength: 100, unicode: false),
                        Sobrenome = c.String(maxLength: 100, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cliente");
        }
    }
}
