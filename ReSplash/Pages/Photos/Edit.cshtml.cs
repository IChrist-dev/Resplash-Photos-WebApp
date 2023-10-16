using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReSplash.Data;
using ReSplash.Models;

namespace ReSplash.Pages.Photos
{
    public class EditModel : PageModel
    {
        private readonly ReSplashContext _context;

        public EditModel(ReSplashContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Photo Photo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Photo == null)
            {
                return NotFound();
            }

            var photo =  await _context.Photo.FirstOrDefaultAsync(m => m.PhotoId == id);
            if (photo == null)
            {
                return NotFound();
            }
            Photo = photo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            User? user = _context.User.Where(u => u.UserId == 1).SingleOrDefault();

            if (user != null)
            {
                Photo.User = user;
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Photo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoExists(Photo.PhotoId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PhotoExists(int id)
        {
          return (_context.Photo?.Any(e => e.PhotoId == id)).GetValueOrDefault();
        }
    }
}
