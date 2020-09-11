namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Menus", "Dimentions", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Menus", "Dimentions", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
