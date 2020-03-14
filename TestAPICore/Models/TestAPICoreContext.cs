using System;
using Microsoft.EntityFrameworkCore;

namespace TestAPICore.Models
{
    public class TestApiCoreContext : DbContext
    {
        public TestApiCoreContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Article> ArticleItems { get; set; }
        public DbSet<Author> AuthorItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<Author>().HasData(
                new Author()
                {
                    Id = 1,
                    FirstName = "George",
                    LastName = "RR Martin"
                },
                new Author()
                {
                    Id = 2,
                    FirstName = "Stephen",
                    LastName = "Fry"
                },
                new Author()
                {
                    Id = 3,
                    FirstName = "James",
                    LastName = "Elroy"
                },
                new Author()
                {
                    Id = 4,
                    FirstName = "Douglas",
                    LastName = "Adams"
                }
            );
            modelBuilder.Entity<Article>().HasData(
                    new Article
                    {
                        Id = 1,
                        AuthorId = 1,
                        Headline = "Eksperter: Det har nul effekt på smitten i Danmark at lukke grænsen nu",
                        Text = "Tidligere direktør for Sundhedsstyrelsen kritiserer historisk beslutning om at lukke de danske grænser. Det er uklart, hvilke anbefalinger regeringen har bygget beslutningen om at lukke grænserne på.",
                        Date = Convert.ToDateTime("2020-04-04T00:00:00")
                    },
                    new Article
                    {
                        Id = 2,
                        AuthorId = 4,
                        Headline = "The Hitchhiker's Guide to the Galaxy",
                        Text = "econds before the Earth is demolished to make way for a galactic freeway, Arthur Dent is plucked off the planet by his friend Ford Prefect, a researcher for the revised edition of The Hitchhiker's Guide to the Galaxy who, for the last fifteen years, has been posing as an out-of-work actor.",
                        Date = Convert.ToDateTime("1979-10-12T00:00:00")
                    }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
