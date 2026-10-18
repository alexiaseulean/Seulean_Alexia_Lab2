using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Seulean_Alexia_Lab2.Data;
using Seulean_Alexia_Lab2.Models;

namespace Seulean_Alexia_Lab2.Pages_Publishers
{
    public class DetailsModel : PageModel
    {
        private readonly Seulean_Alexia_Lab2.Data.Seulean_Alexia_Lab2Context _context;

        public DetailsModel(Seulean_Alexia_Lab2.Data.Seulean_Alexia_Lab2Context context)
        {
            _context = context;
        }

        public Publisher Publisher { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publisher.FirstOrDefaultAsync(m => m.ID == id);

            if (publisher is not null)
            {
                Publisher = publisher;

                return Page();
            }

            return NotFound();
        }
    }
}
