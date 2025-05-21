namespace GymManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePackageTable1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Packages", "DurationDays");
            DropColumn("dbo.Packages", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Packages", "Description", c => c.String());
            AddColumn("dbo.Packages", "DurationDays", c => c.Int(nullable: false));
        }
    }
}
