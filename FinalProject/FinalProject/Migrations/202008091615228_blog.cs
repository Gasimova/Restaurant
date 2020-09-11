namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blog : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blogs", "BlogCategoryId_Id", "dbo.BlogCategories");
            DropIndex("dbo.Blogs", new[] { "BlogCategoryId_Id" });
            RenameColumn(table: "dbo.Blogs", name: "BlogCategoryId_Id", newName: "BlogCategoryId");
            AlterColumn("dbo.Blogs", "BlogCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Blogs", "BlogCategoryId");
            AddForeignKey("dbo.Blogs", "BlogCategoryId", "dbo.BlogCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "BlogCategoryId", "dbo.BlogCategories");
            DropIndex("dbo.Blogs", new[] { "BlogCategoryId" });
            AlterColumn("dbo.Blogs", "BlogCategoryId", c => c.Int());
            RenameColumn(table: "dbo.Blogs", name: "BlogCategoryId", newName: "BlogCategoryId_Id");
            CreateIndex("dbo.Blogs", "BlogCategoryId_Id");
            AddForeignKey("dbo.Blogs", "BlogCategoryId_Id", "dbo.BlogCategories", "Id");
        }
    }
}
