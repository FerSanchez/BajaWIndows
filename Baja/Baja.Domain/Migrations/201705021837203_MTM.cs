namespace Baja.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MTM : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FabricFabricRestrictions",
                c => new
                    {
                        Fabric_Id = c.Int(nullable: false),
                        FabricRestriction_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Fabric_Id, t.FabricRestriction_Id })
                .ForeignKey("dbo.Fabrics", t => t.Fabric_Id, cascadeDelete: true)
                .ForeignKey("dbo.FabricRestrictions", t => t.FabricRestriction_Id, cascadeDelete: true)
                .Index(t => t.Fabric_Id)
                .Index(t => t.FabricRestriction_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FabricFabricRestrictions", "FabricRestriction_Id", "dbo.FabricRestrictions");
            DropForeignKey("dbo.FabricFabricRestrictions", "Fabric_Id", "dbo.Fabrics");
            DropIndex("dbo.FabricFabricRestrictions", new[] { "FabricRestriction_Id" });
            DropIndex("dbo.FabricFabricRestrictions", new[] { "Fabric_Id" });
            DropTable("dbo.FabricFabricRestrictions");
        }
    }
}
