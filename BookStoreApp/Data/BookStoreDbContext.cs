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

            modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Book)
            .HasForeignKey(b => b.AuthorsId);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Book)
                .HasForeignKey(b => b.categoriesId);

            modelBuilder.Entity<Orders>()
                .HasOne(o => o.Book)
                .WithMany(b => b.Orders);
                //.HasForeignKey(o => o.bookId);
        }
    }
}
