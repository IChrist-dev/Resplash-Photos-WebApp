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
        private readonly IWebHostEnvironment _env;

        [BindProperty]
        public Photo Photo { get; set; } = default!;

        [BindProperty]
        public IFormFile ImageUpload { get; set; } = null!;

        public CreateModel(ReSplashContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env; 
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

            string imageName = DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss-") + ImageUpload.FileName;

            Photo.FileName = imageName;
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

            // Save image file, assuming successful insertion to DB
            var file = Path.Combine(_env.ContentRootPath, "wwwroot\\images\\", imageName);

            using (FileStream filestream = new FileStream(file, FileMode.Create))
            {
                ImageUpload.CopyTo(filestream);
            }

            return RedirectToPage("./Index");
        }
    }
}
