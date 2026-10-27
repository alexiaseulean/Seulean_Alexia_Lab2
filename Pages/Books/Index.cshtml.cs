using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Seulean_Alexia_Lab2.Data;
using Seulean_Alexia_Lab2.Models;

namespace Seulean_Alexia_Lab2.Pages_Books
{
    public class IndexModel : PageModel
    {
        private readonly Seulean_Alexia_Lab2.Data.Seulean_Alexia_Lab2Context _context;

        public IndexModel(Seulean_Alexia_Lab2.Data.Seulean_Alexia_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = default!;

        public string? TitleSort { get; set; }
        public string? AuthorSort { get; set; }
        public string? CurrentFilter { get; set; }

        public async Task OnGetAsync(string? sortOrder, string? searchString)
        {
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            AuthorSort = sortOrder == "author" ? "author_desc" : "author";
            CurrentFilter = searchString;

            IEnumerable<Book> books = await _context.Book
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .AsNoTracking()
                .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s =>
                       s.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                    || (s.Author != null &&
                          (s.Author.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                        || s.Author.LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase))));
            }

            switch (sortOrder)
            {
                case "title_desc":
                    books = books.OrderByDescending(s => s.Title);
                    break;
                case "author_desc":
                    books = books.OrderByDescending(s => s.Author?.FullName);
                    break;
                case "author":
                    books = books.OrderBy(s => s.Author?.FullName);
                    break;
                default:
                    books = books.OrderBy(s => s.Title);
                    break;
            }

            Book = books.ToList();
        }
    }
}