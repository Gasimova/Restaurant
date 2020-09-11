namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menu : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Menus", new[] { "menuCategoryId" });
            CreateIndex("dbo.Menus", "MenuCategoryId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Menus", new[] { "MenuCategoryId" });
            CreateIndex("dbo.Menus", "menuCategoryId");
        }
    }
}
