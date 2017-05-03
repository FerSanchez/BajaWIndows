namespace Baja.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FabricManyToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FabricOnRestrictions", "FabricRestrictionId", "dbo.FabricRestrictions");
            DropForeignKey("dbo.FabricOnRestrictions", "FabricId", "dbo.Fabrics");
            DropForeignKey("dbo.Fabrics", "FabricRestriction_Id", "dbo.FabricRestrictions");
            DropIndex("dbo.FabricOnRestrictions", new[] { "FabricId" });
            DropIndex("dbo.FabricOnRestrictions", new[] { "FabricRestrictionId" });
            DropIndex("dbo.Fabrics", new[] { "FabricRestriction_Id" });
            CreateTable(
                "dbo.Fabric_Restriction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FabricId = c.Int(nullable: false),
                        FabricRestrictionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fabrics", t => t.FabricId, cascadeDelete: true)
                .ForeignKey("dbo.FabricRestrictions", t => t.FabricRestrictionId, cascadeDelete: true)
                .Index(t => t.FabricId)
                .Index(t => t.FabricRestrictionId);
            
            DropColumn("dbo.Fabrics", "FabricRestriction_Id");
            DropTable("dbo.FabricOnRestrictions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FabricOnRestrictions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FabricId = c.Int(nullable: false),
                        FabricRestrictionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Fabrics", "FabricRestriction_Id", c => c.Int());
            DropForeignKey("dbo.Fabric_Restriction", "FabricRestrictionId", "dbo.FabricRestrictions");
            DropForeignKey("dbo.Fabric_Restriction", "FabricId", "dbo.Fabrics");
            DropIndex("dbo.Fabric_Restriction", new[] { "FabricRestrictionId" });
            DropIndex("dbo.Fabric_Restriction", new[] { "FabricId" });
            DropTable("dbo.Fabric_Restriction");
            CreateIndex("dbo.Fabrics", "FabricRestriction_Id");
            CreateIndex("dbo.FabricOnRestrictions", "FabricRestrictionId");
            CreateIndex("dbo.FabricOnRestrictions", "FabricId");
            AddForeignKey("dbo.Fabrics", "FabricRestriction_Id", "dbo.FabricRestrictions", "Id");
            AddForeignKey("dbo.FabricOnRestrictions", "FabricId", "dbo.Fabrics", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FabricOnRestrictions", "FabricRestrictionId", "dbo.FabricRestrictions", "Id", cascadeDelete: true);
        }
    }
}
