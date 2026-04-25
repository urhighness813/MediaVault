using MediaVault.Data;
using MediaVault.Interfaces;
using MediaVault.Models;

namespace MediaVault.Repositories
{
    public class SqliteMediaRepository : IMediaRepository
    {
        private readonly MediaVaultDbContext _context;

        public SqliteMediaRepository(MediaVaultDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MediaItem> GetAll()
        {
            return _context.MediaItems.ToList();
        }

        public void Add(MediaItem item)
        {
            _context.MediaItems.Add(item);
            _context.SaveChanges();
        }

        public bool Delete(Guid id)
        {
            var item = _context.MediaItems.Find(id);
            if (item == null) return false;

            _context.MediaItems.Remove(item);
            _context.SaveChanges();
            return true;
        }
    }
}