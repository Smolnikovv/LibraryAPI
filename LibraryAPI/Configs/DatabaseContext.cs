using LibraryAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Configs
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) :base(options) 
        { }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PropGenres(modelBuilder);
            PropAuthors(modelBuilder);
            PropBooks(modelBuilder);
            PropBorrowers(modelBuilder);
        }
        private void PropGenres(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .Property(x => x.Description)
                .IsRequired();
        }
        private void PropAuthors(ModelBuilder modelBuilder) 
        { 
            modelBuilder.Entity<Author>()
                .Property(x => x.Name)
                .IsRequired();
            modelBuilder.Entity<Author>()
                .Property(x => x.Surname)
                .IsRequired();
        }
        private void PropBooks(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Book>()
                .Property(x => x.Name)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .Property(x => x.AuthorId)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .Property(x => x.GenreId)
                .IsRequired();
        }
        private void PropBorrowers(ModelBuilder modelBuilder) 
        { 
            modelBuilder.Entity<Borrower>()
                .Property(x => x.Name)
                .IsRequired();
            modelBuilder.Entity<Borrower>()
                .Property(x => x.DateOfBirth)
                .IsRequired();
            modelBuilder.Entity<Borrower>()
                .Property(x => x.Surname)
                .IsRequired();
        }
    }
}
