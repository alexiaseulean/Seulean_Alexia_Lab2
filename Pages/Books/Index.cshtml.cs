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

        public IList<Book> Book { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Book = await _context.Book
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .ToListAsync();
        }
    }
}