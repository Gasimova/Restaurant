namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userpassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "RepeatPassword", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.Users", "RepeatPassword");
        }
    }
}
