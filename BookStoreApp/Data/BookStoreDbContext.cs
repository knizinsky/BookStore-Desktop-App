using Microsoft.EntityFrameworkCore;

namespace BookStoreApp
{
    public class BookStoreDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Orders> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ACERASPIRE5\\SQLEXPRESS;Initial Catalog=BookShop;Integrated Security=True;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
        }
    }
}
