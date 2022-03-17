using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Smoke.Models;

namespace Smoke.ViewModels
{
    public class SearchResultViewModel : Screen
    {
        private const string NoResultMsg = "No Results Found";
        public string ResultString { get; set; }

        public SearchResultViewModel(SearchResultModel searchResultModel)
        {
            var results = searchResultModel.Results;
            ResultString = results == null || results.Count == 0 
                ? NoResultMsg 
                : string.Join(searchResultModel.Separator, results);
        }
    }
}
