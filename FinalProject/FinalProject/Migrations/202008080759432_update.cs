namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teams", "PositionId_Id", "dbo.Positions");
            DropForeignKey("dbo.Menus", "MenuCategoryId_Id", "dbo.MenuCategories");
            DropForeignKey("dbo.Messages", "BlogId_Id", "dbo.Blogs");
            DropForeignKey("dbo.Messages", "UserId_Id", "dbo.Users");
            DropForeignKey("dbo.Orders", "MenuId_Id", "dbo.Menus");
            DropForeignKey("dbo.Orders", "UserId_Id", "dbo.Users");
            DropForeignKey("dbo.Reviews", "UserId_Id", "dbo.Users");
            DropIndex("dbo.Menus", new[] { "MenuCategoryId_Id" });
            DropIndex("dbo.Messages", new[] { "BlogId_Id" });
            DropIndex("dbo.Messages", new[] { "UserId_Id" });
            DropIndex("dbo.Orders", new[] { "MenuId_Id" });
            DropIndex("dbo.Orders", new[] { "UserId_Id" });
            DropIndex("dbo.Reviews", new[] { "UserId_Id" });
            DropIndex("dbo.Teams", new[] { "PositionId_Id" });
            RenameColumn(table: "dbo.Teams", name: "PositionId_Id", newName: "PositionId");
            RenameColumn(table: "dbo.Menus", name: "MenuCategoryId_Id", newName: "MenuCategoryId");
            RenameColumn(table: "dbo.Messages", name: "BlogId_Id", newName: "BlogId");
            RenameColumn(table: "dbo.Messages", name: "UserId_Id", newName: "UserId");
            RenameColumn(table: "dbo.Orders", name: "MenuId_Id", newName: "MenuId");
            RenameColumn(table: "dbo.Orders", name: "UserId_Id", newName: "UserId");
            RenameColumn(table: "dbo.Reviews", name: "UserId_Id", newName: "UserId");
            AlterColumn("dbo.Menus", "MenuCategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Messages", "BlogId", c => c.Int(nullable: false));
            AlterColumn("dbo.Messages", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "MenuId", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Reviews", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Teams", "PositionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Menus", "MenuCategoryId");
            CreateIndex("dbo.Messages", "UserId");
            CreateIndex("dbo.Messages", "BlogId");
            CreateIndex("dbo.Orders", "UserId");
            CreateIndex("dbo.Orders", "MenuId");
            CreateIndex("dbo.Reviews", "UserId");
            CreateIndex("dbo.Teams", "PositionId");
            AddForeignKey("dbo.Teams", "PositionId", "dbo.Positions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Menus", "MenuCategoryId", "dbo.MenuCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Messages", "BlogId", "dbo.Blogs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Messages", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "MenuId", "dbo.Menus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reviews", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "MenuId", "dbo.Menus");
            DropForeignKey("dbo.Messages", "UserId", "dbo.Users");
            DropForeignKey("dbo.Messages", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.Menus", "MenuCategoryId", "dbo.MenuCategories");
            DropForeignKey("dbo.Teams", "PositionId", "dbo.Positions");
            DropIndex("dbo.Teams", new[] { "PositionId" });
            DropIndex("dbo.Reviews", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "MenuId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Messages", new[] { "BlogId" });
            DropIndex("dbo.Messages", new[] { "UserId" });
            DropIndex("dbo.Menus", new[] { "MenuCategoryId" });
            AlterColumn("dbo.Teams", "PositionId", c => c.Int());
            AlterColumn("dbo.Reviews", "UserId", c => c.Int());
            AlterColumn("dbo.Orders", "UserId", c => c.Int());
            AlterColumn("dbo.Orders", "MenuId", c => c.Int());
            AlterColumn("dbo.Messages", "UserId", c => c.Int());
            AlterColumn("dbo.Messages", "BlogId", c => c.Int());
            AlterColumn("dbo.Menus", "MenuCategoryId", c => c.Int());
            RenameColumn(table: "dbo.Reviews", name: "UserId", newName: "UserId_Id");
            RenameColumn(table: "dbo.Orders", name: "UserId", newName: "UserId_Id");
            RenameColumn(table: "dbo.Orders", name: "MenuId", newName: "MenuId_Id");
            RenameColumn(table: "dbo.Messages", name: "UserId", newName: "UserId_Id");
            RenameColumn(table: "dbo.Messages", name: "BlogId", newName: "BlogId_Id");
            RenameColumn(table: "dbo.Menus", name: "MenuCategoryId", newName: "MenuCategoryId_Id");
            RenameColumn(table: "dbo.Teams", name: "PositionId", newName: "PositionId_Id");
            CreateIndex("dbo.Teams", "PositionId_Id");
            CreateIndex("dbo.Reviews", "UserId_Id");
            CreateIndex("dbo.Orders", "UserId_Id");
            CreateIndex("dbo.Orders", "MenuId_Id");
            CreateIndex("dbo.Messages", "UserId_Id");
            CreateIndex("dbo.Messages", "BlogId_Id");
            CreateIndex("dbo.Menus", "MenuCategoryId_Id");
            AddForeignKey("dbo.Reviews", "UserId_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Orders", "UserId_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Orders", "MenuId_Id", "dbo.Menus", "Id");
            AddForeignKey("dbo.Messages", "UserId_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Messages", "BlogId_Id", "dbo.Blogs", "Id");
            AddForeignKey("dbo.Menus", "MenuCategoryId_Id", "dbo.MenuCategories", "Id");
            AddForeignKey("dbo.Teams", "PositionId_Id", "dbo.Positions", "Id");
        }
    }
}
