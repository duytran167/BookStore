namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImageforBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Pages", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "Author", c => c.String());
            AddColumn("dbo.Books", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "ImageUrl");
            DropColumn("dbo.Books", "Author");
            DropColumn("dbo.Books", "Pages");
        }
    }
}
