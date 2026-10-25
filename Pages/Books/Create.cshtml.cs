using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Seulean_Alexia_Lab2.Data;
using Seulean_Alexia_Lab2.Models;

namespace Seulean_Alexia_Lab2.Pages_Books
{
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Seulean_Alexia_Lab2Context _context;

        public CreateModel(Seulean_Alexia_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        private void LoadLists()
        {
            ViewData["AuthorID"] = new SelectList(_context.Author, "ID", "FullName");
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName");
        }

        public IActionResult OnGet()
        {
            LoadLists();
            var book = new Book { BookCategories = new List<BookCategory>() };
            PopulateAssignedCategoryData(_context, book);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            if (!ModelState.IsValid)
            {
                LoadLists();
                var temp = new Book
                {
                    BookCategories = selectedCategories
                        .Select(c => new BookCategory { CategoryID = int.Parse(c) }).ToList()
                };
                PopulateAssignedCategoryData(_context, temp);
                return Page();
            }

            Book.BookCategories = new List<BookCategory>();
            foreach (var cat in selectedCategories)
            {
                Book.BookCategories.Add(new BookCategory { CategoryID = int.Parse(cat) });
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}