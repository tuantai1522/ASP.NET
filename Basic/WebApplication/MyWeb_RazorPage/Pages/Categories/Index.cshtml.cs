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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<Category> Categories { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_db.Categories != null)
            {
                Categories = await _db.Categories.ToListAsync();
            }
        }
    }
}
