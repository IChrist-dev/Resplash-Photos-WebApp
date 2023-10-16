using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReSplash.Data;
using ReSplash.Models;

namespace ReSplash.Pages.Photos
{
    public class IndexModel : PageModel
    {
        private readonly ReSplashContext _context;
        
        public IList<Photo> Photos { get; set; } = default!;

        public IndexModel(ReSplashContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            if (_context.Photo != null)
            {
                Photos = await _context.Photo.ToListAsync();
            }
        }
    }
}
