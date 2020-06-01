using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diploma_ASP_NET_CORE.Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Diploma_ASP_NET_CORE.Pages.People
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationContext _context;
        public List<Student> People { get; set; }
        public IndexModel(ApplicationContext db)
        {
            _context = db;
        }
        public void OnGet()
        {
            People = _context.People.AsNoTracking().ToList();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var product = await _context.People.FindAsync(id);

            if (product != null)
            {
                _context.People.Remove(product);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}