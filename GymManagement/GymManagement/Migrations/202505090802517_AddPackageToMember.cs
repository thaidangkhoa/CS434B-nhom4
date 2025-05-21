namespace GymManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPackageToMember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "PackageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Members", "PackageId");
            AddForeignKey("dbo.Members", "PackageId", "dbo.Packages", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "PackageId", "dbo.Packages");
            DropIndex("dbo.Members", new[] { "PackageId" });
            DropColumn("dbo.Members", "PackageId");
        }
    }
}
