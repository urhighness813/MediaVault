using MediaVault.Models;
using Microsoft.EntityFrameworkCore;

namespace MediaVault.Data
{
    public class MediaVaultDbContext : DbContext
    {
        public MediaVaultDbContext(DbContextOptions<MediaVaultDbContext> options) : base(options)
        {
        }

        public DbSet<MediaItem> MediaItems { get; set; }
    }
}