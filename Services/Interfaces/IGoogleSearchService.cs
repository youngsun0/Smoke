using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smoke.Services.Interfaces
{
    public interface IGoogleSearchService
    {
        /// <summary>
        ///     Uses the Google Search API to search for URLs based on a query
        /// </summary>
        /// <param name="query">The keywords to search for</param>
        /// <param name="maxSearchResults">The maximum number of results to search for</param>
        /// <returns>Returns a list of URLs</returns>
        Task<IEnumerable<string>> GetUrlsAsync(string query, int maxSearchResults);
    }
}
