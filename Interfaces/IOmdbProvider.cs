using MediaVault.Models;
using System.Collections.Generic;

namespace MediaVault.Interfaces
{
    public interface IOmdbProvider
    {
        Task<OmdbSearchResult?> SearchByTitleAsync(string title);
        Task<OmdbSearchResult?> SearchByImdbIdAsync(string imdbId);
    }
}