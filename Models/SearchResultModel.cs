using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smoke.Models
{
    public class SearchResultModel
    {
        public SearchResultModel(List<int> results, string separator = ", ")
        {
            Results = results;
            Separator = separator;
        }

        public List<int> Results { get; }

        public string Separator { get; }
    }
}
