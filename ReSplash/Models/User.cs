using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ReSplash.Models
{

    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        //[DisplayName("Email Address - Username")]
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public int UserId { get; set; }

        public string Name { get; set; } = string.Empty; 
        
        public string Handle { get; set; } = string.Empty;

        [DisplayName("Available for Hire")]
        public bool AvailableForHire { get; set; } = false;

        public string Location { get; set; } = string.Empty;

        public string Bio { get; set; } = string.Empty;

        public List<Photo> Photos { get; set; } = new();

    }
}
