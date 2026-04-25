using MediaVault.Models;

namespace MediaVault.Interfaces
{
    public interface IMediaRepository
    {
        IEnumerable<MediaItem> GetAll();
        void Add(MediaItem mediaItem);
        bool Delete(Guid id);
    }
}