using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWeb_RazorPage.Data;
using MyWeb_RazorPage.Models;

namespace MyWeb_RazorPage.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
      public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _db.Categories == null || id == 0)
            {
                return NotFound();
            }

            var category = await _db.Categories.FirstOrDefaultAsync(m => m.CategoryID == id);

            if (category == null)
            {
                return NotFound();
            }
            Category = category;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _db.Categories == null || id == 0)
            {
                return NotFound();
            }
            var category = await _db.Categories.FindAsync(id);

            if (category != null)
            {
                Category = category;
                _db.Categories.Remove(Category);
                TempData["success"] = "Category is deleted successfully";
                await _db.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
