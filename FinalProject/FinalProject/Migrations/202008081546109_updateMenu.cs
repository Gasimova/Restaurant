namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMenu : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menus", "MenuCategoryId", "dbo.MenuCategories");
            DropIndex("dbo.Menus", new[] { "MenuCategoryId" });
            AddColumn("dbo.MenuCategories", "Menu_Id", c => c.Int());
            CreateIndex("dbo.MenuCategories", "Menu_Id");
            AddForeignKey("dbo.MenuCategories", "Menu_Id", "dbo.Menus", "Id");
            DropColumn("dbo.Menus", "MenuCategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menus", "MenuCategoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.MenuCategories", "Menu_Id", "dbo.Menus");
            DropIndex("dbo.MenuCategories", new[] { "Menu_Id" });
            DropColumn("dbo.MenuCategories", "Menu_Id");
            CreateIndex("dbo.Menus", "MenuCategoryId");
            AddForeignKey("dbo.Menus", "MenuCategoryId", "dbo.MenuCategories", "Id", cascadeDelete: true);
        }
    }
}
