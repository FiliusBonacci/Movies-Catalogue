namespace MoviesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class settingUp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TagMovies", "Tag_ID", "dbo.Tags");
            DropForeignKey("dbo.TagMovies", "Movie_ID", "dbo.Movies");
            DropIndex("dbo.TagMovies", new[] { "Tag_ID" });
            DropIndex("dbo.TagMovies", new[] { "Movie_ID" });
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Tag_Id", c => c.Int());
            CreateIndex("dbo.Movies", "CategoryId");
            CreateIndex("dbo.Movies", "Tag_Id");
            AddForeignKey("dbo.Movies", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Movies", "Tag_Id", "dbo.Tags", "Id");
            DropTable("dbo.TagMovies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TagMovies",
                c => new
                    {
                        Tag_ID = c.Int(nullable: false),
                        Movie_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_ID, t.Movie_ID });
            
            DropForeignKey("dbo.Movies", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.Movies", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Movies", new[] { "Tag_Id" });
            DropIndex("dbo.Movies", new[] { "CategoryId" });
            DropColumn("dbo.Movies", "Tag_Id");
            DropColumn("dbo.Movies", "CategoryId");
            DropTable("dbo.Categories");
            CreateIndex("dbo.TagMovies", "Movie_ID");
            CreateIndex("dbo.TagMovies", "Tag_ID");
            AddForeignKey("dbo.TagMovies", "Movie_ID", "dbo.Movies", "ID", cascadeDelete: true);
            AddForeignKey("dbo.TagMovies", "Tag_ID", "dbo.Tags", "ID", cascadeDelete: true);
        }
    }
}
