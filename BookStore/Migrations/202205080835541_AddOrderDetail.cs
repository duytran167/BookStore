namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Datetime = c.DateTime(nullable: false),
                        Book_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Book_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderDetails", "Book_Id", "dbo.Books");
            DropIndex("dbo.OrderDetails", new[] { "User_Id" });
            DropIndex("dbo.OrderDetails", new[] { "Book_Id" });
            DropTable("dbo.OrderDetails");
        }
    }
}
