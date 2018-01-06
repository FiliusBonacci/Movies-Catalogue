namespace MoviesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reviewChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "Movie_ID", "dbo.Movies");
            DropIndex("dbo.Reviews", new[] { "Movie_ID" });
            RenameColumn(table: "dbo.Reviews", name: "Movie_ID", newName: "MovieId");
            AlterColumn("dbo.Reviews", "MovieId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reviews", "MovieId");
            AddForeignKey("dbo.Reviews", "MovieId", "dbo.Movies", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "MovieId", "dbo.Movies");
            DropIndex("dbo.Reviews", new[] { "MovieId" });
            AlterColumn("dbo.Reviews", "MovieId", c => c.Int());
            RenameColumn(table: "dbo.Reviews", name: "MovieId", newName: "Movie_ID");
            CreateIndex("dbo.Reviews", "Movie_ID");
            AddForeignKey("dbo.Reviews", "Movie_ID", "dbo.Movies", "ID");
        }
    }
}
