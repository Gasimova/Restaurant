namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accordions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 500),
                        Text = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Filial = c.String(maxLength: 100),
                        Street = c.String(maxLength: 500),
                        Phone = c.Int(nullable: false),
                        Email = c.String(maxLength: 100),
                        Weekday = c.String(),
                        Weekend = c.String(),
                        Image = c.String(),
                        Map = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false),
                        Image = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BlogCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 1000),
                        Date = c.DateTime(nullable: false),
                        Author = c.String(maxLength: 100),
                        Image = c.String(),
                        Text = c.String(storeType: "ntext"),
                        CreatedDate = c.DateTime(nullable: false),
                        BlogCategoryId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogCategories", t => t.BlogCategoryId_Id)
                .Index(t => t.BlogCategoryId_Id);
            
            CreateTable(
                "dbo.Galeries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InstaFeeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Link = c.String(),
                        Image = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MenuCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 500),
                        Image = c.String(),
                        Description = c.String(storeType: "ntext"),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Dimentions = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MenuCategoryId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuCategories", t => t.MenuCategoryId_Id)
                .Index(t => t.MenuCategoryId_Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(maxLength: 2000),
                        CreatedDate = c.DateTime(nullable: false),
                        BlogId_Id = c.Int(),
                        UserId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blogs", t => t.BlogId_Id)
                .ForeignKey("dbo.Users", t => t.UserId_Id)
                .Index(t => t.BlogId_Id)
                .Index(t => t.UserId_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Surname = c.String(nullable: false, maxLength: 200),
                        Username = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 10),
                        Phone = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDate = c.DateTime(nullable: false),
                        MenuId_Id = c.Int(),
                        UserId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.MenuId_Id)
                .ForeignKey("dbo.Users", t => t.UserId_Id)
                .Index(t => t.MenuId_Id)
                .Index(t => t.UserId_Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Position = c.String(),
                        Reviews = c.String(),
                        Image = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UserId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId_Id)
                .Index(t => t.UserId_Id);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Surname = c.String(maxLength: 200),
                        Facebook = c.String(),
                        Instagram = c.String(),
                        Twitter = c.String(),
                        Image = c.String(),
                        PositionId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Positions", t => t.PositionId_Id)
                .Index(t => t.PositionId_Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Requests = c.String(maxLength: 2000),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HeaderLogo = c.String(),
                        FooterLogo = c.String(),
                        Facebook = c.String(),
                        Instagram = c.String(),
                        Twitter = c.String(),
                        MasterCard = c.String(),
                        Visa = c.String(),
                        Weekday = c.String(),
                        Weekend = c.String(),
                        Phone = c.Int(nullable: false),
                        EstablishDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 500),
                        Subtitle = c.String(maxLength: 1000),
                        Description = c.String(maxLength: 2000),
                        Type = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subscribes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WeAreVincents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SubTitle = c.String(),
                        Text = c.String(storeType: "ntext"),
                        Image1 = c.String(),
                        Image2 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "PositionId_Id", "dbo.Positions");
            DropForeignKey("dbo.Reviews", "UserId_Id", "dbo.Users");
            DropForeignKey("dbo.Orders", "UserId_Id", "dbo.Users");
            DropForeignKey("dbo.Orders", "MenuId_Id", "dbo.Menus");
            DropForeignKey("dbo.Messages", "UserId_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "BlogId_Id", "dbo.Blogs");
            DropForeignKey("dbo.Menus", "MenuCategoryId_Id", "dbo.MenuCategories");
            DropForeignKey("dbo.Blogs", "BlogCategoryId_Id", "dbo.BlogCategories");
            DropIndex("dbo.Teams", new[] { "PositionId_Id" });
            DropIndex("dbo.Reviews", new[] { "UserId_Id" });
            DropIndex("dbo.Orders", new[] { "UserId_Id" });
            DropIndex("dbo.Orders", new[] { "MenuId_Id" });
            DropIndex("dbo.Messages", new[] { "UserId_Id" });
            DropIndex("dbo.Messages", new[] { "BlogId_Id" });
            DropIndex("dbo.Menus", new[] { "MenuCategoryId_Id" });
            DropIndex("dbo.Blogs", new[] { "BlogCategoryId_Id" });
            DropTable("dbo.WeAreVincents");
            DropTable("dbo.Tags");
            DropTable("dbo.Subscribes");
            DropTable("dbo.Sliders");
            DropTable("dbo.Settings");
            DropTable("dbo.Reservations");
            DropTable("dbo.Teams");
            DropTable("dbo.Positions");
            DropTable("dbo.Reviews");
            DropTable("dbo.Orders");
            DropTable("dbo.Users");
            DropTable("dbo.Messages");
            DropTable("dbo.Menus");
            DropTable("dbo.MenuCategories");
            DropTable("dbo.InstaFeeds");
            DropTable("dbo.Galeries");
            DropTable("dbo.Blogs");
            DropTable("dbo.BlogCategories");
            DropTable("dbo.Admins");
            DropTable("dbo.Addresses");
            DropTable("dbo.Accordions");
        }
    }
}
