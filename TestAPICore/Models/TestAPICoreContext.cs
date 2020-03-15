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
        public DbSet<Author> Authors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .HasOne(b => b.Author);

            // seed the database with dummy data
            modelBuilder.Entity<Author>().HasData(
                new Author()
                {
                    AuthorId = 1,
                    FirstName = "George",
                    LastName = "RR Martin"
                },
                new Author()
                {
                    AuthorId = 2,
                    FirstName = "Stephen",
                    LastName = "Fry"
                },
                new Author()
                {
                    AuthorId = 3,
                    FirstName = "James",
                    LastName = "Ellroy"
                },
                new Author()
                {
                    AuthorId = 4,
                    FirstName = "Douglas",
                    LastName = "Adams"
                }
            );
            modelBuilder.Entity<Article>().HasData(
                    new Article
                    {
                        Id = 1,
                        Headline = "Eksperter: Det har nul effekt på smitten i Danmark at lukke grænsen nu",
                        Text = "Tidligere direktør for Sundhedsstyrelsen kritiserer historisk beslutning om at lukke de danske grænser. Det er uklart, hvilke anbefalinger regeringen har bygget beslutningen om at lukke grænserne på.",
                        Date = Convert.ToDateTime("2020-04-04T00:00:00"),
                        AuthorId = 2
                    },
                    new Article
                    {
                        Id = 2,
                        Headline = "The Hitchhiker's Guide to the Galaxy",
                        Text = "econds before the Earth is demolished to make way for a galactic freeway, Arthur Dent is plucked off the planet by his friend Ford Prefect, a researcher for the revised edition of The Hitchhiker's Guide to the Galaxy who, for the last fifteen years, has been posing as an out-of-work actor.",
                        Date = Convert.ToDateTime("1979-10-12T00:00:00"),
                        AuthorId = 4
                    }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
