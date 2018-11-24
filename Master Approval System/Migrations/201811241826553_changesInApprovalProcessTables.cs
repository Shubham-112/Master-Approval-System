namespace Master_Approval_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesInApprovalProcessTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApprovalProcesses", "Level", c => c.String());
            AddColumn("dbo.Levels", "Approvers", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Levels", "Approvers");
            DropColumn("dbo.ApprovalProcesses", "Level");
        }
    }
}
