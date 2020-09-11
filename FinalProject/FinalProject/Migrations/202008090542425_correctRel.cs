namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctRel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenuCategories", "Menu_Id", "dbo.Menus");
            DropIndex("dbo.MenuCategories", new[] { "Menu_Id" });
            AddColumn("dbo.MenuCategories", "MenuCategory_Id", c => c.Int());
            AddColumn("dbo.Menus", "menuCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.MenuCategories", "MenuCategory_Id");
            CreateIndex("dbo.Menus", "menuCategoryId");
            AddForeignKey("dbo.MenuCategories", "MenuCategory_Id", "dbo.MenuCategories", "Id");
            AddForeignKey("dbo.Menus", "menuCategoryId", "dbo.MenuCategories", "Id", cascadeDelete: true);
            DropColumn("dbo.MenuCategories", "Menu_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MenuCategories", "Menu_Id", c => c.Int());
            DropForeignKey("dbo.Menus", "menuCategoryId", "dbo.MenuCategories");
            DropForeignKey("dbo.MenuCategories", "MenuCategory_Id", "dbo.MenuCategories");
            DropIndex("dbo.Menus", new[] { "menuCategoryId" });
            DropIndex("dbo.MenuCategories", new[] { "MenuCategory_Id" });
            DropColumn("dbo.Menus", "menuCategoryId");
            DropColumn("dbo.MenuCategories", "MenuCategory_Id");
            CreateIndex("dbo.MenuCategories", "Menu_Id");
            AddForeignKey("dbo.MenuCategories", "Menu_Id", "dbo.Menus", "Id");
        }
    }
}
