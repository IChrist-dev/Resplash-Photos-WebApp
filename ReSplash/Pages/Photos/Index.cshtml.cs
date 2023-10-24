using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReSplash.Data;
using ReSplash.Models;

namespace ReSplash.Pages.Photos
{
    [Authorize]
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
                int userId = int.Parse(User.Identity.Name);

                // Include tag info for each photo by doing JOINs
                Photos = await _context.Photo.Where(u => u.User.UserId == userId).Include("Category").Include("PhotoTags").Include("PhotoTags.Tag").OrderByDescending(d => d.PublishDate).ToListAsync();
            }
        }
    }
}
