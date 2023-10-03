using Microsoft.EntityFrameworkCore;

namespace ReSplash.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Handle { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public bool AvailableForHire { get; set; } = false;

        public string UserType { get; set; } = string.Empty;

        List<Photo> Photos { get; set; } = new List<Photo>();

    }
}
