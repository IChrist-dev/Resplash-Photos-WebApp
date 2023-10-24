using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReSplash.Data;
using ReSplash.Models;

namespace ReSplash.Pages.Users
{
    public class RegisterModel : PageModel
    {
        private readonly ReSplashContext _context;

        [BindProperty]
        public User User { get; set; } = default!;

        // Constructor
        public RegisterModel(ReSplashContext context)
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
            if (!ModelState.IsValid || _context.User == null || User == null)
            {
                return Page();
            }

            // Encrypt password
            User.Password = BCrypt.Net.BCrypt.HashPassword(User.Password);

            _context.User.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Users/Login");
        }
    }
}
