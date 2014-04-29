namespace FitFlow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Belongs",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        ApplyFrom = c.DateTime(nullable: false, storeType: "date"),
                        ApplyTo = c.DateTime(nullable: false, storeType: "date"),
                        DutyType = c.Int(nullable: false),
                        CreateUserId = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                        UpdateUserId = c.Int(),
                        UpdateDateTime = c.DateTime(),
                        DeleteFlg = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.DepartmentId, t.ApplyFrom })
                .ForeignKey("dbo.Users", t => t.CreateUserId, cascadeDelete: false)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UpdateUserId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.CreateUserId)
                .Index(t => t.DepartmentId)
                .Index(t => t.UpdateUserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Alias = c.String(nullable: false),
                        Domain = c.String(),
                        CreateUserId = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                        UpdateUserId = c.Int(),
                        UpdateDateTime = c.DateTime(),
                        DeleteFlg = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ParentId = c.Int(nullable: false),
                        Name = c.String(),
                        ApplyFrom = c.DateTime(nullable: false, storeType: "date"),
                        ApplyTo = c.DateTime(nullable: false, storeType: "date"),
                        CreateUserId = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                        UpdateUserId = c.Int(),
                        UpdateDateTime = c.DateTime(),
                        DeleteFlg = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreateUserId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UpdateUserId)
                .Index(t => t.CreateUserId)
                .Index(t => t.UpdateUserId);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Category = c.String(),
                        Name = c.String(),
                        URL = c.String(),
                        Icon = c.String(),
                        Order = c.Int(),
                        CreateUserId = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                        UpdateUserId = c.Int(),
                        UpdateDateTime = c.DateTime(),
                        DeleteFlg = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreateUserId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UpdateUserId)
                .Index(t => t.CreateUserId)
                .Index(t => t.UpdateUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "UpdateUserId", "dbo.Users");
            DropForeignKey("dbo.Menus", "CreateUserId", "dbo.Users");
            DropForeignKey("dbo.Belongs", "UserId", "dbo.Users");
            DropForeignKey("dbo.Belongs", "UpdateUserId", "dbo.Users");
            DropForeignKey("dbo.Belongs", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "UpdateUserId", "dbo.Users");
            DropForeignKey("dbo.Departments", "CreateUserId", "dbo.Users");
            DropForeignKey("dbo.Belongs", "CreateUserId", "dbo.Users");
            DropIndex("dbo.Menus", new[] { "UpdateUserId" });
            DropIndex("dbo.Menus", new[] { "CreateUserId" });
            DropIndex("dbo.Belongs", new[] { "UserId" });
            DropIndex("dbo.Belongs", new[] { "UpdateUserId" });
            DropIndex("dbo.Belongs", new[] { "DepartmentId" });
            DropIndex("dbo.Departments", new[] { "UpdateUserId" });
            DropIndex("dbo.Departments", new[] { "CreateUserId" });
            DropIndex("dbo.Belongs", new[] { "CreateUserId" });
            DropTable("dbo.Menus");
            DropTable("dbo.Departments");
            DropTable("dbo.Users");
            DropTable("dbo.Belongs");
        }
    }
}
