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
                        UserId = c.String(nullable: false, maxLength: 128),
                        DepartmentId = c.String(nullable: false, maxLength: 128),
                        Role = c.Int(nullable: false),
                        Duty = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false, storeType: "date"),
                        EndDate = c.DateTime(nullable: false, storeType: "date"),
                        CreateUserId = c.String(nullable: false, maxLength: 128),
                        CreateDateTime = c.DateTime(nullable: false),
                        UpdateUserId = c.String(maxLength: 128),
                        UpdateDateTime = c.DateTime(),
                        DeleteFlg = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.DepartmentId, t.StartDate })
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
                        Id = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        CreateUserId = c.String(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                        UpdateUserId = c.String(),
                        UpdateDateTime = c.DateTime(),
                        DeleteFlg = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ParentId = c.String(),
                        Level = c.Int(nullable: false),
                        CreateUserId = c.String(nullable: false, maxLength: 128),
                        CreateDateTime = c.DateTime(nullable: false),
                        UpdateUserId = c.String(maxLength: 128),
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
                        CreateUserId = c.String(nullable: false, maxLength: 128),
                        CreateDateTime = c.DateTime(nullable: false),
                        UpdateUserId = c.String(maxLength: 128),
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
