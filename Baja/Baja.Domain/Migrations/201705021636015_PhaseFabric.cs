namespace Baja.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhaseFabric : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FabricBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FabricCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FabricCategories", t => t.FabricCategoryId, cascadeDelete: true)
                .Index(t => t.FabricCategoryId);
            
            CreateTable(
                "dbo.FabricCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FabricRestrictions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fabrics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImageUrl = c.String(),
                        FabricBookId = c.Int(nullable: false),
                        FabricRestrictionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FabricBooks", t => t.FabricBookId, cascadeDelete: true)
                .ForeignKey("dbo.FabricRestrictions", t => t.FabricRestrictionId, cascadeDelete: true)
                .Index(t => t.FabricBookId)
                .Index(t => t.FabricRestrictionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fabrics", "FabricRestrictionId", "dbo.FabricRestrictions");
            DropForeignKey("dbo.Fabrics", "FabricBookId", "dbo.FabricBooks");
            DropForeignKey("dbo.FabricBooks", "FabricCategoryId", "dbo.FabricCategories");
            DropIndex("dbo.Fabrics", new[] { "FabricRestrictionId" });
            DropIndex("dbo.Fabrics", new[] { "FabricBookId" });
            DropIndex("dbo.FabricBooks", new[] { "FabricCategoryId" });
            DropTable("dbo.Fabrics");
            DropTable("dbo.FabricRestrictions");
            DropTable("dbo.FabricCategories");
            DropTable("dbo.FabricBooks");
        }
    }
}
