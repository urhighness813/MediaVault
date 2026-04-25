

namespace MediaVault.Models
{
    public class MediaItem
    {
        public Guid Id { get; set; }
        public string ImdbId { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Format { get; set; }
        public DateTime DateAdded { get; set; }
    }
}