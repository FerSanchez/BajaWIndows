namespace Baja.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrimRestrictiosnEdit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Trim_Restrictions", "Restrictions_Id", "dbo.Restrictions");
            DropIndex("dbo.Trim_Restrictions", new[] { "Restrictions_Id" });
            RenameColumn(table: "dbo.Trim_Restrictions", name: "Restrictions_Id", newName: "RestrictionsId");
            AlterColumn("dbo.Trim_Restrictions", "RestrictionsId", c => c.Int(nullable: false));
            CreateIndex("dbo.Trim_Restrictions", "RestrictionsId");
            AddForeignKey("dbo.Trim_Restrictions", "RestrictionsId", "dbo.Restrictions", "Id", cascadeDelete: true);
            DropColumn("dbo.Trim_Restrictions", "RestrictionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trim_Restrictions", "RestrictionId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Trim_Restrictions", "RestrictionsId", "dbo.Restrictions");
            DropIndex("dbo.Trim_Restrictions", new[] { "RestrictionsId" });
            AlterColumn("dbo.Trim_Restrictions", "RestrictionsId", c => c.Int());
            RenameColumn(table: "dbo.Trim_Restrictions", name: "RestrictionsId", newName: "Restrictions_Id");
            CreateIndex("dbo.Trim_Restrictions", "Restrictions_Id");
            AddForeignKey("dbo.Trim_Restrictions", "Restrictions_Id", "dbo.Restrictions", "Id");
        }
    }
}
