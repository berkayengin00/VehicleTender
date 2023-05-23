namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migv5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleMenu",
                c => new
                    {
                        RolId = c.String(nullable: false, maxLength: 128),
                        MenuId = c.String(nullable: false, maxLength: 128),
                        Menu_Id = c.Int(),
                        Role_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.RolId, t.MenuId })
                .ForeignKey("dbo.Menus", t => t.Menu_Id)
                .ForeignKey("dbo.Role", t => t.Role_Id)
                .Index(t => t.Menu_Id)
                .Index(t => t.Role_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleMenu", "Role_Id", "dbo.Role");
            DropForeignKey("dbo.RoleMenu", "Menu_Id", "dbo.Menus");
            DropIndex("dbo.RoleMenu", new[] { "Role_Id" });
            DropIndex("dbo.RoleMenu", new[] { "Menu_Id" });
            DropTable("dbo.RoleMenu");
            DropTable("dbo.Menus");
        }
    }
}
