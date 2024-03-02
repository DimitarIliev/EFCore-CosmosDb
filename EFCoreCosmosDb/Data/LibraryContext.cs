using EFCoreCosmosDb.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCosmosDb.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        #region Configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseCosmos(
                "AccountEndpoint=https://iliev-cosmos-db.documents.azure.com:443/;AccountKey=oe9H5r7wnVZS83KdXNbagVYQWNribdZeCvgMCelpLT7iLehNOTZXsmylW9i9DaPlviql1YcgTb50ACDbx0ARjA==;",
                databaseName: "studentdb");
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Container
            modelBuilder.Entity<Book>()
                .ToContainer("Books");
            #endregion

            #region PartitionKey
            modelBuilder.Entity<Book>()
                .HasPartitionKey(o => o.PartitionKey);
            #endregion

            #region ETag
            modelBuilder.Entity<Book>()
                .UseETagConcurrency();
            #endregion

            #region NoDiscriminator
            modelBuilder.Entity<Book>()
                .HasNoDiscriminator();
            #endregion

        }
    }
}
