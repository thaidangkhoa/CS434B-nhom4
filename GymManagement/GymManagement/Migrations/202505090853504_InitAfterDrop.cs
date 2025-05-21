namespace GymManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitAfterDrop : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Members", "PackageId", "dbo.Packages");
            DropIndex("dbo.Members", new[] { "PackageId" });
            AlterColumn("dbo.Members", "PackageId", c => c.Int());
            CreateIndex("dbo.Members", "PackageId");
            AddForeignKey("dbo.Members", "PackageId", "dbo.Packages", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "PackageId", "dbo.Packages");
            DropIndex("dbo.Members", new[] { "PackageId" });
            AlterColumn("dbo.Members", "PackageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Members", "PackageId");
            AddForeignKey("dbo.Members", "PackageId", "dbo.Packages", "Id", cascadeDelete: true);
        }
    }
}
