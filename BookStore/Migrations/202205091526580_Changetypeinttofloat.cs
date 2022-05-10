namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changetypeinttofloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Price", c => c.Single(nullable: false));
            AlterColumn("dbo.Books", "Quantity", c => c.Single(nullable: false));
            AlterColumn("dbo.OrderDetails", "TotalPrice", c => c.Single(nullable: false));
            AlterColumn("dbo.OrderDetails", "Quantity", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderDetails", "Quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "TotalPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "Quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "Price", c => c.Int(nullable: false));
        }
    }
}
