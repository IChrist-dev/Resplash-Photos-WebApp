using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReSplash.Data;
using ReSplash.Models;

namespace ReSplash.Pages.Photos
{
    public class CreateModel : PageModel
    {
        private readonly ReSplash.Data.ReSplashContext _context;
        
        [BindProperty]
        public Photo Photo { get; set; } = default!;

        public CreateModel(ReSplash.Data.ReSplashContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }   

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            // Set default values

            User? user = _context.User.Where(u => u.UserId == 1).SingleOrDefault();

            if (user != null)
            {
                Photo.User = user;
            }

            // TO-DO - get the actual image file name
            Photo.FileName = "";
            Photo.PublishDate = DateTime.Now;
            Photo.ImageViews = 0;
            Photo.ImageDownloads = 0;

            // Validate model
            if (!ModelState.IsValid || _context.Photo == null || Photo == null)
            {
                return Page();
            }

            // Save to database
            _context.Photo.Add(Photo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
