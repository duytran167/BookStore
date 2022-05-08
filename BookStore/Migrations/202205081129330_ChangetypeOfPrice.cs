namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangetypeOfPrice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Price", c => c.String());
        }
    }
}
