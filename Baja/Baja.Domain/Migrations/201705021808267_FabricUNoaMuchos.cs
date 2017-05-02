namespace Baja.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FabricUNoaMuchos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Fabrics", "FabricRestrictionId", "dbo.FabricRestrictions");
            DropIndex("dbo.Fabrics", new[] { "FabricRestrictionId" });
            DropColumn("dbo.Fabrics", "FabricRestrictionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fabrics", "FabricRestrictionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Fabrics", "FabricRestrictionId");
            AddForeignKey("dbo.Fabrics", "FabricRestrictionId", "dbo.FabricRestrictions", "Id", cascadeDelete: true);
        }
    }
}
