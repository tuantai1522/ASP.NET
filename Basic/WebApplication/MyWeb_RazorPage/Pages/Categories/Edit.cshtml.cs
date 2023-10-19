using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWeb_RazorPage.Data;
using MyWeb_RazorPage.Models;

namespace MyWeb_RazorPage.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
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

            var category =  await _db.Categories.FirstOrDefaultAsync(m => m.CategoryID == id);
            if (category == null)
            {
                return NotFound();
            }
            Category = category;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ////First Solution:
            //_db.Attach(Category).State = EntityState.Modified;

            //try
            //{
            //    TempData["success"] = "Category is updated successfully";
            //    await _db.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!CategoryExists(Category.CategoryID))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return RedirectToPage("./Index");

            ////Second Solution:
            _db.Categories.Update(Category);
            TempData["success"] = "Category is updated successfully";
            _db.SaveChanges();
            return RedirectToPage("./Index");

        }

        private bool CategoryExists(int id)
        {
          return (_db.Categories?.Any(e => e.CategoryID == id)).GetValueOrDefault();
        }
    }
}
