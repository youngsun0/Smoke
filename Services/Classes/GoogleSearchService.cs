using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;
using Smoke.Services.Interfaces;

namespace Smoke.Services.Classes
{
    public class GoogleSearchService : IGoogleSearchService
    {
        public async Task<IEnumerable<string>> GetUrlsAsync(string query, int maxSearchResults)
        {
            var apiKey = System.Configuration.ConfigurationManager.AppSettings["GoogleApiKey"];
            var cx = System.Configuration.ConfigurationManager.AppSettings["GoogleCx"];

            var svc = new CustomsearchService(new BaseClientService.Initializer { ApiKey = apiKey });
            var listRequest = svc.Cse.List();
            listRequest.Cx = cx;
            listRequest.Q = query;

            var urls = new List<string>();

            while (urls.Count < maxSearchResults)
            {
                listRequest.Start = urls.Count + 1;    // Index starts at 1 as per Google API doc

                Search search;
                // Exceptions thrown when start Index is too high or we reach API call limit
                try
                {
                    search = await listRequest.ExecuteAsync();
                }
                catch (Exception ex)
                {
                    break;
                }

                if (search.Items == null) break;

                urls.AddRange(search.Items.Select(x => x.DisplayLink).ToList());
            }

            return urls.Take(maxSearchResults);
        }
    }
}
