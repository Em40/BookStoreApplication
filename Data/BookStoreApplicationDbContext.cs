using BookStoreApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreApplication.Data
{
    public class BookStoreApplicationDbContext : IdentityDbContext
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookAuthor> BookAuthors { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Magazine> Magazines { get; set; }

        public DbSet<Notebook> Notebooks { get; set; }

        public DbSet<OfficeSupply> OfficeSupplies { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public BookStoreApplicationDbContext(DbContextOptions<BookStoreApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.BookId, ba.AuthorId });
            modelBuilder.Entity<Publisher>()
                    .HasMany(p => p.Magazines)
                    .WithOne(m => m.Publisher);
        }
    }
}
