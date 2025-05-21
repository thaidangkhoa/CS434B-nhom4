namespace GymManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMemberModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "CreatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "CreatedAt");
        }
    }

}
