

namespace MediaVault.Models
{
    public class OmdbSearchResult
    {
        public string ImdbId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Year { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public string Director { get; set; } = string.Empty;
        public string Response { get; set; } = string.Empty;
    }
}