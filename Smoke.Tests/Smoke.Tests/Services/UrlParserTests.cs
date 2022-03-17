using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Smoke.Services.Classes;

namespace Smoke.Tests.Services
{
    public class UrlParserTests
    {
        private UrlParser _urlParser;

        [SetUp]
        public void Setup()
        {
            _urlParser = new UrlParser();
        }

        [Test]
        public void ParseUrls_WhenUrlsIsNull_ReturnsEmptyList()
        {
            var result = _urlParser.ParseUrls(null, null);

            Assert.IsEmpty(result);
        }

        [Test]
        public void ParseUrls_WhenUrlsIsEmpty_ReturnsEmptyList()
        {
            var urls = new List<string>();

            var result = _urlParser.ParseUrls(urls, null);

            Assert.IsEmpty(result);
        }

        [Test]
        public void ParseUrls_WhenTargetUrlDoesntExist_ReturnsEmptyList()
        {
            var urls = new List<string>
            {
                "smokeball.com.au"
            };

            var result = _urlParser.ParseUrls(urls, "fake.url");

            Assert.IsEmpty(result);
        }

        [Test]
        public void ParseUrls_WhenTargetUrlExists_ReturnsIndexesStartingFrom1()
        {
            var url = "smokeball.com.au";
            var urls = new List<string>
            {
                url
            };

            var result = _urlParser.ParseUrls(urls, url);

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0] == 1);
        }

        [Test]
        public void ParseUrls_WhenAllUrlsMatch_ReturnsCorrectNumberOfIndexes()
        {
            var url = "smokeball.com.au";
            var urls = new List<string>
            {
                url,
                url,
                url,
                url,
                url
            };

            var result = _urlParser.ParseUrls(urls, url);

            Assert.IsTrue(result.Count == 5);
            for (int i = 0; i < 5; i++)
            {
                Assert.IsTrue(result[i] == i + 1);
            }
        }

        [Test]
        public void ParseUrls_WhenSomeUrlsMatch_ReturnsCorrectNumberOfIndexes()
        {
            var url = "smokeball.com.au";
            var urls = new List<string>
            {
                url,
                url,
                "fake.url",
                url,
                url
            };

            var result = _urlParser.ParseUrls(urls, url);

            Assert.IsTrue(result.Count == 4);
        }
    }
}
