namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctMenu : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenuCategories", "MenuCategory_Id", "dbo.MenuCategories");
            DropIndex("dbo.MenuCategories", new[] { "MenuCategory_Id" });
            DropColumn("dbo.MenuCategories", "MenuCategory_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MenuCategories", "MenuCategory_Id", c => c.Int());
            CreateIndex("dbo.MenuCategories", "MenuCategory_Id");
            AddForeignKey("dbo.MenuCategories", "MenuCategory_Id", "dbo.MenuCategories", "Id");
        }
    }
}
