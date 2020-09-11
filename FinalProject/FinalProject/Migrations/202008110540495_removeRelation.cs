namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "UserId", "dbo.Users");
            DropIndex("dbo.Reviews", new[] { "UserId" });
            RenameColumn(table: "dbo.Reviews", name: "UserId", newName: "User_Id");
            AlterColumn("dbo.Admins", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Reviews", "User_Id", c => c.Int());
            CreateIndex("dbo.Reviews", "User_Id");
            AddForeignKey("dbo.Reviews", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "User_Id", "dbo.Users");
            DropIndex("dbo.Reviews", new[] { "User_Id" });
            AlterColumn("dbo.Reviews", "User_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Admins", "Password", c => c.String(nullable: false, maxLength: 10));
            RenameColumn(table: "dbo.Reviews", name: "User_Id", newName: "UserId");
            CreateIndex("dbo.Reviews", "UserId");
            AddForeignKey("dbo.Reviews", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
