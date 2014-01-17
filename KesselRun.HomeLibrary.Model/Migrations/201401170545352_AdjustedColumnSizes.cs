namespace KesselRun.HomeLibrary.Model.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AdjustedColumnSizes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.People", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.People", "FirstName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.People", "LastName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.People", "Sobriquet", c => c.String(maxLength: 30));
            AlterColumn("dbo.Comments", "CommentText", c => c.String(nullable: false));
            AlterColumn("dbo.Publishers", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Publishers", "Name", c => c.String());
            AlterColumn("dbo.Comments", "CommentText", c => c.String());
            AlterColumn("dbo.People", "Sobriquet", c => c.String());
            AlterColumn("dbo.People", "LastName", c => c.String());
            AlterColumn("dbo.People", "FirstName", c => c.String());
            AlterColumn("dbo.People", "Email", c => c.String());
            AlterColumn("dbo.Books", "Title", c => c.String());
        }
    }
}
