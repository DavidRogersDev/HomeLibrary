namespace KesselRun.HomeLibrary.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookCovers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        Edition = c.Int(nullable: false),
                        Cover = c.Binary(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 4000),
                        Edition = c.Int(nullable: false),
                        PublisherId = c.Int(nullable: false),
                        TypeOfBook = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Publishers", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.PublisherId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 4000),
                        IsAuthor = c.Boolean(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 4000),
                        LastName = c.String(nullable: false, maxLength: 4000),
                        Sobriquet = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lendings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        BorrowerId = c.Int(nullable: false),
                        DateLent = c.DateTime(nullable: false),
                        DueDate = c.DateTime(),
                        ReturnDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.BorrowerId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.BorrowerId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        CommentText = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonBooks",
                c => new
                    {
                        Person_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.Book_Id })
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Person_Id)
                .Index(t => t.Book_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.BookCovers", "BookId", "dbo.Books");
            DropForeignKey("dbo.Comments", "BookId", "dbo.Books");
            DropForeignKey("dbo.Lendings", "BorrowerId", "dbo.People");
            DropForeignKey("dbo.Lendings", "BookId", "dbo.Books");
            DropForeignKey("dbo.PersonBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.PersonBooks", "Person_Id", "dbo.People");
            DropIndex("dbo.Books", new[] { "PublisherId" });
            DropIndex("dbo.BookCovers", new[] { "BookId" });
            DropIndex("dbo.Comments", new[] { "BookId" });
            DropIndex("dbo.Lendings", new[] { "BorrowerId" });
            DropIndex("dbo.Lendings", new[] { "BookId" });
            DropIndex("dbo.PersonBooks", new[] { "Book_Id" });
            DropIndex("dbo.PersonBooks", new[] { "Person_Id" });
            DropTable("dbo.PersonBooks");
            DropTable("dbo.Publishers");
            DropTable("dbo.Comments");
            DropTable("dbo.Lendings");
            DropTable("dbo.People");
            DropTable("dbo.Books");
            DropTable("dbo.BookCovers");
        }
    }
}
