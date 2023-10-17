namespace ReSplash.Models
{
    public class Tag
    {
        public int Id { get; set; }
        
        public string TagName { get; set; } = string.Empty;
        
        public List<PhotoTag> PhotoTags = new();
    }
}
