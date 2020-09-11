namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changePass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "RepeatPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "RepeatPassword", c => c.String(nullable: false));
        }
    }
}
