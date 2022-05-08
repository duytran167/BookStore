namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderDetail2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "Book_Id", "dbo.Books");
            DropIndex("dbo.OrderDetails", new[] { "Book_Id" });
            RenameColumn(table: "dbo.OrderDetails", name: "Book_Id", newName: "BookID");
            RenameColumn(table: "dbo.OrderDetails", name: "User_Id", newName: "UserID");
            RenameIndex(table: "dbo.OrderDetails", name: "IX_User_Id", newName: "IX_UserID");
            AlterColumn("dbo.OrderDetails", "BookID", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderDetails", "BookID");
            AddForeignKey("dbo.OrderDetails", "BookID", "dbo.Books", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "BookID", "dbo.Books");
            DropIndex("dbo.OrderDetails", new[] { "BookID" });
            AlterColumn("dbo.OrderDetails", "BookID", c => c.Int());
            RenameIndex(table: "dbo.OrderDetails", name: "IX_UserID", newName: "IX_User_Id");
            RenameColumn(table: "dbo.OrderDetails", name: "UserID", newName: "User_Id");
            RenameColumn(table: "dbo.OrderDetails", name: "BookID", newName: "Book_Id");
            CreateIndex("dbo.OrderDetails", "Book_Id");
            AddForeignKey("dbo.OrderDetails", "Book_Id", "dbo.Books", "Id");
        }
    }
}
