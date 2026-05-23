/* using MediaVault.Interfaces;
using MediaVault.Models;

namespace MediaVault.Repositories
{
    public class MediaRepository : IMediaRepository
    {
        private readonly List<MediaItem> _items = new();

        public IEnumerable<MediaItem> GetAll()
        {
            return _items;
        }

        public void Add(MediaItem item)
        {
            _items.Add(item);
        }

        public bool Delete(Guid id)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
            if (item is null) return false;

            _items.Remove(item);
            return true;
        }
    }
} */