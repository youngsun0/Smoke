using System.Collections.Generic;

namespace Smoke.Services.Interfaces
{
    public interface IUrlParser
    {
        /// <summary>
        ///     Gets a list of urls and returns the indexes in which the targetUrl resides
        ///     Indexes start from 1
        /// </summary>
        /// <param name="urls">List of URLs</param>
        /// <param name="targetUrl">The URL that we are searching for</param>
        /// <returns>List of Indexes starting from 1 where the target URL resides</returns>
        List<int> ParseUrls(List<string> urls, string targetUrl);
    }
}
