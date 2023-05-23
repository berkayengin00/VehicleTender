namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migv9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoleMenu", "Role_Id", "dbo.Role");
            DropIndex("dbo.RoleMenu", new[] { "Role_Id" });
            RenameColumn(table: "dbo.RoleMenu", name: "Role_Id", newName: "RoleId");
            DropPrimaryKey("dbo.RoleMenu");
            AlterColumn("dbo.RoleMenu", "RoleId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.RoleMenu", new[] { "RoleId", "MenuId" });
            CreateIndex("dbo.RoleMenu", "RoleId");
            AddForeignKey("dbo.RoleMenu", "RoleId", "dbo.Role", "Id", cascadeDelete: true);
            DropColumn("dbo.RoleMenu", "RolId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoleMenu", "RolId", c => c.Int(nullable: false));
            DropForeignKey("dbo.RoleMenu", "RoleId", "dbo.Role");
            DropIndex("dbo.RoleMenu", new[] { "RoleId" });
            DropPrimaryKey("dbo.RoleMenu");
            AlterColumn("dbo.RoleMenu", "RoleId", c => c.Int());
            AddPrimaryKey("dbo.RoleMenu", new[] { "RolId", "MenuId" });
            RenameColumn(table: "dbo.RoleMenu", name: "RoleId", newName: "Role_Id");
            CreateIndex("dbo.RoleMenu", "Role_Id");
            AddForeignKey("dbo.RoleMenu", "Role_Id", "dbo.Role", "Id");
        }
    }
}
