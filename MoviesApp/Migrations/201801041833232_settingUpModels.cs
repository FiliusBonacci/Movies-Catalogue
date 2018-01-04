namespace MoviesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class settingUpModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tags", "Movie_ID", "dbo.Movies");
            DropIndex("dbo.Tags", new[] { "Movie_ID" });
            CreateTable(
                "dbo.TagMovies",
                c => new
                    {
                        Tag_ID = c.Int(nullable: false),
                        Movie_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_ID, t.Movie_ID })
                .ForeignKey("dbo.Tags", t => t.Tag_ID, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_ID, cascadeDelete: true)
                .Index(t => t.Tag_ID)
                .Index(t => t.Movie_ID);
            
            DropColumn("dbo.Tags", "Movie_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "Movie_ID", c => c.Int());
            DropForeignKey("dbo.TagMovies", "Movie_ID", "dbo.Movies");
            DropForeignKey("dbo.TagMovies", "Tag_ID", "dbo.Tags");
            DropIndex("dbo.TagMovies", new[] { "Movie_ID" });
            DropIndex("dbo.TagMovies", new[] { "Tag_ID" });
            DropTable("dbo.TagMovies");
            CreateIndex("dbo.Tags", "Movie_ID");
            AddForeignKey("dbo.Tags", "Movie_ID", "dbo.Movies", "ID");
        }
    }
}
