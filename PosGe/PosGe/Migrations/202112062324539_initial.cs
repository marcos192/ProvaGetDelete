namespace PosGe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fornecedors",
                c => new
                    {
                        FornecedorId = c.Long(nullable: false, identity: true),
                        nome = c.String(),
                    })
                .PrimaryKey(t => t.FornecedorId);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        ProdutoId = c.Long(nullable: false, identity: true),
                        nome = c.String(),
                    })
                .PrimaryKey(t => t.ProdutoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Produtoes");
            DropTable("dbo.Fornecedors");
        }
    }
}
