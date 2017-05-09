namespace Baja.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrimTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restrictions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trim_Restrictions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrimId = c.Int(nullable: false),
                        RestrictionId = c.Int(nullable: false),
                        Restrictions_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restrictions", t => t.Restrictions_Id)
                .ForeignKey("dbo.Trims", t => t.TrimId, cascadeDelete: true)
                .Index(t => t.TrimId)
                .Index(t => t.Restrictions_Id);
            
            AddColumn("dbo.Trims", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trim_Restrictions", "TrimId", "dbo.Trims");
            DropForeignKey("dbo.Trim_Restrictions", "Restrictions_Id", "dbo.Restrictions");
            DropIndex("dbo.Trim_Restrictions", new[] { "Restrictions_Id" });
            DropIndex("dbo.Trim_Restrictions", new[] { "TrimId" });
            DropColumn("dbo.Trims", "ImageUrl");
            DropTable("dbo.Trim_Restrictions");
            DropTable("dbo.Restrictions");
        }
    }
}
