using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReSplash.Data;
using ReSplash.Models;

namespace ReSplash.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ReSplashContext _context;

        public IList<Photo> Photos { get; set; } = default!;

        public IndexModel(ILogger<IndexModel> logger, ReSplashContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            if (_context.Photo != null)
            {
                Photos = _context.Photo.OrderByDescending(d => d.PublishDate).ToList();
            }
        }
    }
}