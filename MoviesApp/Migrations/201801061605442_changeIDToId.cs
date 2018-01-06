namespace MoviesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeIDToId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Movies", new[] { "Tag_ID" });
            CreateIndex("dbo.Movies", "Tag_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Movies", new[] { "Tag_Id" });
            CreateIndex("dbo.Movies", "Tag_ID");
        }
    }
}
