namespace Baja.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FFR1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FabricFabricRestrictions", "Fabric_Id", "dbo.Fabrics");
            DropForeignKey("dbo.FabricFabricRestrictions", "FabricRestriction_Id", "dbo.FabricRestrictions");
            DropIndex("dbo.FabricFabricRestrictions", new[] { "Fabric_Id" });
            DropIndex("dbo.FabricFabricRestrictions", new[] { "FabricRestriction_Id" });
            CreateTable(
                "dbo.FabricOnRestrictions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FabricId = c.Int(nullable: false),
                        FabricRestrictionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FabricRestrictions", t => t.FabricRestrictionId, cascadeDelete: true)
                .ForeignKey("dbo.Fabrics", t => t.FabricId, cascadeDelete: true)
                .Index(t => t.FabricId)
                .Index(t => t.FabricRestrictionId);
            
            AddColumn("dbo.Fabrics", "FabricRestriction_Id", c => c.Int());
            CreateIndex("dbo.Fabrics", "FabricRestriction_Id");
            AddForeignKey("dbo.Fabrics", "FabricRestriction_Id", "dbo.FabricRestrictions", "Id");
            DropTable("dbo.FabricFabricRestrictions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FabricFabricRestrictions",
                c => new
                    {
                        Fabric_Id = c.Int(nullable: false),
                        FabricRestriction_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Fabric_Id, t.FabricRestriction_Id });
            
            DropForeignKey("dbo.Fabrics", "FabricRestriction_Id", "dbo.FabricRestrictions");
            DropForeignKey("dbo.FabricOnRestrictions", "FabricId", "dbo.Fabrics");
            DropForeignKey("dbo.FabricOnRestrictions", "FabricRestrictionId", "dbo.FabricRestrictions");
            DropIndex("dbo.FabricOnRestrictions", new[] { "FabricRestrictionId" });
            DropIndex("dbo.FabricOnRestrictions", new[] { "FabricId" });
            DropIndex("dbo.Fabrics", new[] { "FabricRestriction_Id" });
            DropColumn("dbo.Fabrics", "FabricRestriction_Id");
            DropTable("dbo.FabricOnRestrictions");
            CreateIndex("dbo.FabricFabricRestrictions", "FabricRestriction_Id");
            CreateIndex("dbo.FabricFabricRestrictions", "Fabric_Id");
            AddForeignKey("dbo.FabricFabricRestrictions", "FabricRestriction_Id", "dbo.FabricRestrictions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FabricFabricRestrictions", "Fabric_Id", "dbo.Fabrics", "Id", cascadeDelete: true);
        }
    }
}
