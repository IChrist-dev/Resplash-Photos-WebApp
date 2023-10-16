using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace ReSplash.Models
{
    public class Photo
    {
        public int PhotoId { get; set; }

        [DisplayName("File Name")]
        public string FileName { get; set; } = string.Empty;

        [DataType(DataType.DateTime)]
        [DisplayName("Publish Date")]
        public DateTime PublishDate { get; set; }

        public string Description { get; set; } = string.Empty;

        [DisplayName("Views")]
        public int ImageViews { get; set; }

        [DisplayName("Downloads")]
        public int ImageDownloads { get; set; }

        public string Location { get; set; } = string.Empty;

        public User User { get; set; } = new();

        public Category Category { get; set; } = new();
    }
}
