using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Seulean_Alexia_Lab2.Data;
using Seulean_Alexia_Lab2.Models;

namespace Seulean_Alexia_Lab2.Pages_Books
{
    public class DetailsModel : PageModel
    {
        private readonly Seulean_Alexia_Lab2Context _context;

        public DetailsModel(Seulean_Alexia_Lab2Context context)
        {
            _context = context;
        }

        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (book == null)
            {
                return NotFound();
            }

            Book = book;
            return Page();
        }
    }
}