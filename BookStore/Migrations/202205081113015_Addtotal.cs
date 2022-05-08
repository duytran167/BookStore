namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addtotal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "TotalPrice", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "Quantity");
            DropColumn("dbo.OrderDetails", "TotalPrice");
        }
    }
}
