using MediaVault.Models;


namespace MediaVault.Interfaces;
public interface IMediaService
{
    IEnumerable<MediaItem> GetCollection();
    Task<OmdbSearchResult?> SearchAsync(string title);
    Task<MediaItem?> AddAsync(string imdbId, string format);
    bool Remove(Guid id);
}