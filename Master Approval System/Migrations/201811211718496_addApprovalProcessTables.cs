namespace Master_Approval_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addApprovalProcessTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApprovalProcesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Levels");
            DropTable("dbo.ApprovalProcesses");
        }
    }
}
