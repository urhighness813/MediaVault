using MediaVault.Interfaces;
using MediaVault.Models;

namespace MediaVault.Services
{
    public class MediaService : IMediaService   
    {
        private readonly IMediaRepository _repository;
        private readonly IOmdbProvider _omdbProvider;

        public MediaService(IMediaRepository repository, IOmdbProvider omdbProvider)
        {
            _repository = repository;
            _omdbProvider = omdbProvider;
        }

        public IEnumerable<MediaItem> GetCollection()
        {
            return _repository.GetAll();
        }

        public async Task<OmdbSearchResult?> SearchAsync(string title)
        {
            return await _omdbProvider.SearchByTitleAsync(title);
        }
    
        public async Task<MediaItem?> AddAsync(string imdbId, string format)
        {
            var searchResult = await _omdbProvider.SearchByTitleAsync(imdbId);

            if (searchResult is null) return null;

            var item = new MediaItem
            {
                Id = Guid.NewGuid(),
                ImdbId = searchResult.ImdbId,
                Title = searchResult.Title,
                Year = searchResult.Year,
                Genre = searchResult.Genre,
                Director = searchResult.Director,
                Format = format,
                DateAdded = DateTime.UtcNow
            };

            _repository.Add(item);
            return item;
        }

        public bool Remove(Guid id)
        {
            return _repository.Delete(id);
        }
    }
}