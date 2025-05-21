namespace GymManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePackageModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Packages", "Duration", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Packages", "Duration");
        }
    }
}
