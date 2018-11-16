namespace Master_Approval_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesToAspNetUsers : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetRoles", newName: "Roles");
            RenameTable(name: "dbo.AspNetUserRoles", newName: "UserRoles");
            RenameTable(name: "dbo.AspNetUsers", newName: "Users");
            RenameTable(name: "dbo.AspNetUserClaims", newName: "UserClaims");
            RenameTable(name: "dbo.AspNetUserLogins", newName: "UserLogins");
            AddColumn("dbo.Users", "CompanyId", c => c.Int());
            AddColumn("dbo.Users", "Address", c => c.String());
            AddColumn("dbo.Users", "Post", c => c.String());
            AddColumn("dbo.Users", "salary", c => c.String());
            AddColumn("dbo.Users", "SalaryProcessRequestId", c => c.Int());
            AddColumn("dbo.Users", "SalaryMasterRequestId", c => c.Int());
            AddColumn("dbo.Users", "ProfileUpdateRequestId", c => c.Int());
            CreateIndex("dbo.Users", "CompanyId");
            CreateIndex("dbo.Users", "SalaryProcessRequestId");
            CreateIndex("dbo.Users", "SalaryMasterRequestId");
            CreateIndex("dbo.Users", "ProfileUpdateRequestId");
            AddForeignKey("dbo.Users", "CompanyId", "dbo.Companies", "Id");
            AddForeignKey("dbo.Users", "ProfileUpdateRequestId", "dbo.ProfileUpdateRequests", "Id");
            AddForeignKey("dbo.Users", "SalaryMasterRequestId", "dbo.SalaryMasterRequests", "Id");
            AddForeignKey("dbo.Users", "SalaryProcessRequestId", "dbo.SalaryProcessRequests", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "SalaryProcessRequestId", "dbo.SalaryProcessRequests");
            DropForeignKey("dbo.Users", "SalaryMasterRequestId", "dbo.SalaryMasterRequests");
            DropForeignKey("dbo.Users", "ProfileUpdateRequestId", "dbo.ProfileUpdateRequests");
            DropForeignKey("dbo.Users", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Users", new[] { "ProfileUpdateRequestId" });
            DropIndex("dbo.Users", new[] { "SalaryMasterRequestId" });
            DropIndex("dbo.Users", new[] { "SalaryProcessRequestId" });
            DropIndex("dbo.Users", new[] { "CompanyId" });
            DropColumn("dbo.Users", "ProfileUpdateRequestId");
            DropColumn("dbo.Users", "SalaryMasterRequestId");
            DropColumn("dbo.Users", "SalaryProcessRequestId");
            DropColumn("dbo.Users", "salary");
            DropColumn("dbo.Users", "Post");
            DropColumn("dbo.Users", "Address");
            DropColumn("dbo.Users", "CompanyId");
            RenameTable(name: "dbo.UserLogins", newName: "AspNetUserLogins");
            RenameTable(name: "dbo.UserClaims", newName: "AspNetUserClaims");
            RenameTable(name: "dbo.Users", newName: "AspNetUsers");
            RenameTable(name: "dbo.UserRoles", newName: "AspNetUserRoles");
            RenameTable(name: "dbo.Roles", newName: "AspNetRoles");
        }
    }
}
