using MediaVault.Models;

namespace MediaVault.Interfaces
{
    public interface IMediaRepository
    {
        IEnumerable<MediaItem> GetAll();
        void AddMediaItem(MediaItem mediaItem);
        bool DeleteMediaItemAsync(Guid id);
    }
}