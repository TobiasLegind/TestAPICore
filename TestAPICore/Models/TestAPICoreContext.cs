using Microsoft.EntityFrameworkCore;

namespace TestAPICore.Models
{
    public class TestApiCoreContext : DbContext
    {
        public TestApiCoreContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Article> ArticleItems { get; set; }
    }
}
