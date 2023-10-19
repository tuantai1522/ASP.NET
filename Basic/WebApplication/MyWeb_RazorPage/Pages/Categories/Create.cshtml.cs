using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWeb_RazorPage.Data;
using MyWeb_RazorPage.Models;

namespace MyWeb_RazorPage.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] //important when adding new categories
        public Category Category { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            if (Category.CaterogyName == Category.DisplayOrder.ToString()) // to add my custom error when checking
            {
                ModelState.AddModelError("ModelOnly", "Name and Display order can not be the same");
            }
            if (!ModelState.IsValid || _db.Categories == null || Category == null)
            {
                return Page();
            }

            _db.Categories.Add(Category);
            await _db.SaveChangesAsync();
            TempData["success"] = "Category is created successfully";

            return RedirectToPage("./Index");
        }
    }
}
