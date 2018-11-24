namespace Master_Approval_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesInLevelsAndApprovalProcess : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ApprovalProcesses", "Status");
            DropColumn("dbo.Levels", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Levels", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.ApprovalProcesses", "Status", c => c.Int(nullable: false));
        }
    }
}
