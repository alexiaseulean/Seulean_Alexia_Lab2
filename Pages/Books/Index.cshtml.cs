using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Seulean_Alexia_Lab2.Data;
using Seulean_Alexia_Lab2.Models;

namespace Seulean_Alexia_Lab2.Pages_Books
{
    public class IndexModel : PageModel
    {
        private readonly Seulean_Alexia_Lab2Context _context;

        public IndexModel(Seulean_Alexia_Lab2Context context)
        {
            _context = context;
        }

        public BookData BookD { get; set; } = new BookData();
        public int BookID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            BookD = new BookData();

            BookD.Books = await _context.Book
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .OrderBy(b => b.Title)
                .ToListAsync();

            if (id != null)
            {
                BookID = id.Value;
                var book = BookD.Books.FirstOrDefault(i => i.ID == id.Value);
                if (book != null && book.BookCategories != null)
                {
                    BookD.Categories = book.BookCategories.Select(s => s.Category!);
                }
            }
        }
    }
}