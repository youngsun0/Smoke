using System.Collections.Generic;
using Smoke.Services.Interfaces;

namespace Smoke.Services.Classes
{
    public class UrlParser : IUrlParser
    {
        public List<int> ParseUrls(List<string> urls, string targetUrl)
        {
            var indexes = new List<int>();

            if (urls == null) return indexes;

            for (var i = 0; i < urls.Count; i++)
            {
                if (urls[i].Contains(targetUrl))
                {
                    indexes.Add(i + 1);
                }
            }

            return indexes;
        }
    }
}
