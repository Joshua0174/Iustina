using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class MyDbContext : IdentityDbContext<User>
    {
        private readonly string _windowsConnectionString = @"Server=.\SQLExpress;Database=TAPDatabaseIustinaFinal;Trusted_Connection=True;TrustServerCertificate=true";

        public DbSet<TestModel> TestModels { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_windowsConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Book>()
           .HasMany(s => s.Comments)
           .WithOne(r => r.Book)
           .HasForeignKey(r => r.BookId);

        }
    }
}
