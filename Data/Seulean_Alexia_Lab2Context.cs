using Microsoft.EntityFrameworkCore;
using Seulean_Alexia_Lab2.Models;

namespace Seulean_Alexia_Lab2.Data
{
    public class Seulean_Alexia_Lab2Context : DbContext
    {
        public Seulean_Alexia_Lab2Context(DbContextOptions<Seulean_Alexia_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; } = default!;
        public DbSet<Publisher> Publisher { get; set; } = default!;
        public DbSet<Author> Author { get; set; } = default!;
        public DbSet<Category> Category { get; set; } = default!;
        public DbSet<BookCategory> BookCategory { get; set; } = default!;
    }
}