namespace Master_Approval_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Post = c.String(),
                        salary = c.String(),
                        SalaryProcessRequestId = c.Int(),
                        SalaryMasterRequestId = c.Int(),
                        ProfileUpdateRequestId = c.Int(),
                        Name = c.String(),
                        EmpId = c.Int(nullable: false),
                        Phone = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        CompanyId = c.Int(),
                        EmployeeId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.ProfileUpdateRequests", t => t.ProfileUpdateRequestId)
                .ForeignKey("dbo.SalaryMasterRequests", t => t.SalaryMasterRequestId)
                .ForeignKey("dbo.SalaryProcessRequests", t => t.SalaryProcessRequestId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.SalaryProcessRequestId)
                .Index(t => t.SalaryMasterRequestId)
                .Index(t => t.ProfileUpdateRequestId)
                .Index(t => t.CompanyId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProfileUpdateRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        DOB = c.DateTime(),
                        JoiningDate = c.DateTime(),
                        JoiningAge = c.Int(nullable: false),
                        Gender = c.String(),
                        RetirementAge = c.Int(nullable: false),
                        IndustryType = c.String(),
                        BloodGroup = c.String(),
                        Client = c.String(),
                        ClientSub = c.String(),
                        AgreementType = c.String(),
                        JobLocation = c.String(),
                        Division = c.String(),
                        MaritalStatus = c.Boolean(nullable: false),
                        ContractType = c.String(),
                        PTState = c.String(),
                        AssociationType = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        State = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SalaryMasterRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActualBasic = c.Single(nullable: false),
                        HRA = c.Single(nullable: false),
                        TransportAllowance = c.Single(nullable: false),
                        SpecialAllowance = c.Single(nullable: false),
                        MedicalAllowance = c.Single(nullable: false),
                        CCA = c.Int(nullable: false),
                        OtherAllowance = c.Single(nullable: false),
                        BonusFixed = c.Single(nullable: false),
                        Incentive = c.Single(nullable: false),
                        OtherEarnings = c.Single(nullable: false),
                        EmpPF = c.Int(nullable: false),
                        EmprPF = c.Int(nullable: false),
                        EmpESI = c.Int(nullable: false),
                        EmprESI = c.Int(nullable: false),
                        PT = c.Single(nullable: false),
                        ITDeduction = c.Single(nullable: false),
                        LWF = c.Single(nullable: false),
                        OtherDeduction = c.Single(nullable: false),
                        GrossDeduction = c.Single(nullable: false),
                        OtherAdvance = c.Single(nullable: false),
                        FesAdb = c.Single(nullable: false),
                        Total = c.Single(nullable: false),
                        NetEarning = c.Single(nullable: false),
                        Gratuity = c.Single(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        State = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SalaryProcessRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Initiated = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        State = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Employees", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "SalaryProcessRequestId", "dbo.SalaryProcessRequests");
            DropForeignKey("dbo.Employees", "SalaryMasterRequestId", "dbo.SalaryMasterRequests");
            DropForeignKey("dbo.Employees", "ProfileUpdateRequestId", "dbo.ProfileUpdateRequests");
            DropForeignKey("dbo.Employees", "CompanyId", "dbo.Companies");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Employees", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "CompanyId" });
            DropIndex("dbo.Employees", new[] { "ProfileUpdateRequestId" });
            DropIndex("dbo.Employees", new[] { "SalaryMasterRequestId" });
            DropIndex("dbo.Employees", new[] { "SalaryProcessRequestId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.SalaryProcessRequests");
            DropTable("dbo.SalaryMasterRequests");
            DropTable("dbo.ProfileUpdateRequests");
            DropTable("dbo.Companies");
            DropTable("dbo.Employees");
        }
    }
}
