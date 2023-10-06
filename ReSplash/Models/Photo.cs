using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ReSplash.Models
{
    public class Photo
    {
        public int PhotoId { get; set; }

        [DisplayName("File Name")]
        public string FileName { get; set; } = string.Empty;

        [DataType(DataType.DateTime)]
        public DateTime PublishDate { get; set; }

        public string Description { get; set; } = string.Empty;

        public int ImageViews { get; set; }

        public int ImageDownloads { get; set; }

        public string Location { get; set; } = string.Empty;

        public User User { get; set; } = new(); 

    }
}
