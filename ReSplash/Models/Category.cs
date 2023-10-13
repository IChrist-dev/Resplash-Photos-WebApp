using System.ComponentModel;

namespace ReSplash.Models
{
    public class Category
    {
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [DisplayName("Category")]
        public string CategoryName { get; set; } = string.Empty;

        public List<Photo> Photos { get; set; } = new();
    }
}
