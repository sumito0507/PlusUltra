namespace MvcMovie.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcMovie.Models.MovieDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcMovie.Models.MovieDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Movies.AddOrUpdate(i => i.Title,
                new Models.Movie
                {
                    Title = "êmã`Ç»Ç´êÌÇ¢",
                    Director = "ê[çÏã”ìÒ",
                    ReleaseDate = DateTime.Parse("1973-1-13"),
                    Genre = "Ç‚Ç≠Ç¥",
                    Price = 7990M
                },
                new Models.Movie
                {
                    Title = "The Yakuza Papers 2:Deadly Fight in Hiroshima",
                    Director = "ê[çÏã”ìÒ",
                    ReleaseDate = DateTime.Parse("1973-4-28"),
                    Genre = "Yakuza",
                    Price = 6990M
                }
                );
        }
    }
}
