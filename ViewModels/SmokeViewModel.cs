using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Caliburn.Micro;
using Smoke.Models;
using Smoke.Services;
using Smoke.Services.Interfaces;

namespace Smoke.ViewModels
{
    public class SmokeViewModel : Conductor<object>
    {
        private const int MaxSearchResults = 100;
        private readonly IGoogleSearchService _googleSearchService;
        private readonly IUrlParser _urlParser;
        private string _query;
        private string _url;
        private bool _isSearching;

        public SmokeViewModel(IGoogleSearchService googleSearchService, IUrlParser urlParser)
        {
            _googleSearchService = googleSearchService;
            _urlParser = urlParser;
        }

        public string Query
        {
            get => _query;
            set
            {
                _query = value;
                NotifyOfPropertyChange(() => IsSearchButtonEnabled);
            }
        }
        public string Url
        {
            get => _url;
            set
            {
                _url = value;
                NotifyOfPropertyChange(() => IsSearchButtonEnabled);
            }
        }

        public bool IsSearchButtonEnabled => !IsSearching && !string.IsNullOrWhiteSpace(Query) && !string.IsNullOrWhiteSpace(Url);

        public bool IsSearching
        {
            get => _isSearching;
            set
            {
                _isSearching = value;
                NotifyOfPropertyChange(() => IsSearchButtonEnabled);
            }
        }

        public async void Search()
        {
            IsSearching = true;
            ActivateItem(null);

            var urls = await _googleSearchService.GetUrlsAsync(Query, MaxSearchResults);
            var indexes = _urlParser.ParseUrls(urls.ToList(), Url);

            ActivateItem(new SearchResultViewModel(new SearchResultModel(indexes)));
            IsSearching = false;
        }
    }
}
