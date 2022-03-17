using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Smoke.Services.Interfaces;
using Smoke.ViewModels;

namespace Smoke.Tests.ViewModels
{
    public class SmokeViewModelTests
    {
        private SmokeViewModel _smokeViewModel;
        private Mock<IGoogleSearchService> _googleSearchService;
        private Mock<IUrlParser> _urlParser;

        [SetUp]
        public void Setup()
        {
            _googleSearchService = new Mock<IGoogleSearchService>();
            _urlParser = new Mock<IUrlParser>();
            _smokeViewModel = new SmokeViewModel(_googleSearchService.Object, _urlParser.Object);
        }

        [Test]
        public void SearchButton_WhenNotSearching_AndQueryNotEmpty_AndUrlNotEmpty_ShouldBeEnabled()
        {
            _smokeViewModel.IsSearching = false;
            _smokeViewModel.Query = "query";
            _smokeViewModel.Url = "url";

            Assert.IsTrue(_smokeViewModel.IsSearchButtonEnabled);
        }

        [TestCase(true, "q", "u")]
        [TestCase(false, "", "u")]
        [TestCase(false, null, "u")]
        [TestCase(false, "q", "")]
        [TestCase(false, "q", null)]
        [TestCase(false, "", null)]
        [TestCase(false, null, "")]
        public void SearchButton_WhenSearching_OrQueryEmpty_OrUrlEmpty_ShouldBeDisabled(bool isSearching, string query, string url)
        {
            _smokeViewModel.IsSearching = isSearching;
            _smokeViewModel.Query = query;
            _smokeViewModel.Url = url;

            Assert.IsFalse(_smokeViewModel.IsSearchButtonEnabled);
        }

        [Test]
        public void VerifySearchCallsCorrectServicesOnce()
        {
            _smokeViewModel.Search();
            _googleSearchService.Verify(x => x.GetUrlsAsync(It.IsAny<string>(), It.IsAny<int>()), Times.Once);
            _urlParser.Verify(x => x.ParseUrls(It.IsAny<List<string>>(), It.IsAny<string>()), Times.Once);
        }
    }
}
