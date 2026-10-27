using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Seulean_Alexia_Lab2.Models;
using Seulean_Alexia_Lab2.Data;

namespace Seulean_Alexia_Lab2.Pages.CategoryPages;

public class IndexModel : PageModel
{
    private readonly Seulean_Alexia_Lab2Context _context;

    public IndexModel(Seulean_Alexia_Lab2Context context)
    {
        _context = context;
    }

    public IList<Category> Category { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Category = await _context.Category.ToListAsync();
    }
}
