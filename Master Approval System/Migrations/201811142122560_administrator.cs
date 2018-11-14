namespace Master_Approval_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class administrator : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "EmployeeId" });
            AddColumn("dbo.Employees", "AdminId", c => c.Int());
            DropColumn("dbo.Employees", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "EmployeeId", c => c.Int());
            DropColumn("dbo.Employees", "AdminId");
            CreateIndex("dbo.Employees", "EmployeeId");
            AddForeignKey("dbo.Employees", "EmployeeId", "dbo.Employees", "Id");
        }
    }
}
