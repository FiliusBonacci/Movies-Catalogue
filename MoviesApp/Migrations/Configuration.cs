namespace MoviesApp.Migrations
{
    using MoviesApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MoviesApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MoviesApp.Models.ApplicationDbContext context)
        {
            context.Tags.AddOrUpdate(t => t.Name, new Tag { Name = "Filmy sensacyjne" }, new Tag { Name = "Dramaty" });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
