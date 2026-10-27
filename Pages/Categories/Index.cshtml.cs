using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Seulean_Alexia_Lab2.Data;
using Seulean_Alexia_Lab2.Models;
using Seulean_Alexia_Lab2.Models.ViewModels;

namespace Seulean_Alexia_Lab2.Pages_Categories
{
    public class IndexModel : PageModel
    {
        private readonly Seulean_Alexia_Lab2.Data.Seulean_Alexia_Lab2Context _context;

        public IndexModel(Seulean_Alexia_Lab2.Data.Seulean_Alexia_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;

        public CategoryIndexData CategoryData { get; set; } = default!;
        public int CategoryID { get; set; }
        public int BookID { get; set; }

        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
                .Include(i => i.BookCategories)
                    .ThenInclude(i => i.Book)
                        .ThenInclude(c => c.Author)
                .OrderBy(i => i.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                    .Where(i => i.ID == id.Value).Single();
                CategoryData.Books = category.BookCategories.Select(b => b.Book);
            }
        }
    }
}