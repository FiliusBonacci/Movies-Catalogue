namespace MoviesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoviesCreation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Tag_ID", "dbo.Tags");
            DropIndex("dbo.Movies", new[] { "Tag_ID" });
            AddColumn("dbo.Tags", "Movie_ID", c => c.Int());
            CreateIndex("dbo.Tags", "Movie_ID");
            AddForeignKey("dbo.Tags", "Movie_ID", "dbo.Movies", "ID");
            DropColumn("dbo.Movies", "Tag_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Tag_ID", c => c.Int());
            DropForeignKey("dbo.Tags", "Movie_ID", "dbo.Movies");
            DropIndex("dbo.Tags", new[] { "Movie_ID" });
            DropColumn("dbo.Tags", "Movie_ID");
            CreateIndex("dbo.Movies", "Tag_ID");
            AddForeignKey("dbo.Movies", "Tag_ID", "dbo.Tags", "ID");
        }
    }
}
