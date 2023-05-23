namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migv8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoleMenu", "Menu_Id", "dbo.Menu");
            DropForeignKey("dbo.RoleMenu", "Role_Id", "dbo.Role");
            DropIndex("dbo.RoleMenu", new[] { "Menu_Id" });
            DropIndex("dbo.RoleMenu", new[] { "Role_Id" });
            DropTable("dbo.RoleMenu");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RoleMenu",
                c => new
                    {
                        RolId = c.String(nullable: false, maxLength: 128),
                        MenuId = c.String(nullable: false, maxLength: 128),
                        Menu_Id = c.Int(),
                        Role_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.RolId, t.MenuId });
            
            CreateIndex("dbo.RoleMenu", "Role_Id");
            CreateIndex("dbo.RoleMenu", "Menu_Id");
            AddForeignKey("dbo.RoleMenu", "Role_Id", "dbo.Role", "Id");
            AddForeignKey("dbo.RoleMenu", "Menu_Id", "dbo.Menu", "Id");
        }
    }
}
