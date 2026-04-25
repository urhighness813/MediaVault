

namespace MediaVault.Models
{
    public class MediaItem
    {
        public Guid Id { get; set; }
        public string ImdbId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Year { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public string Director { get; set; } = null!;
        public string Format { get; set; } = null!;
        public DateTime DateAdded { get; set; }
    }
}