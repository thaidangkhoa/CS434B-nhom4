namespace GymManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTrialRegistrationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrialRegistrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        PackageId = c.Int(),
                        Notes = c.String(),
                        RegisteredAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.PackageId)
                .Index(t => t.PackageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrialRegistrations", "PackageId", "dbo.Packages");
            DropIndex("dbo.TrialRegistrations", new[] { "PackageId" });
            DropTable("dbo.TrialRegistrations");
        }
    }
}
