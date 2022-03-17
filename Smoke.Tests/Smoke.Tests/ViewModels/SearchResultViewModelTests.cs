using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Smoke.Models;
using Smoke.Services.Classes;
using Smoke.ViewModels;

namespace Smoke.Tests.ViewModels
{
    public class SearchResultViewModelTests
    {
        private const string NoResultMsg = "No Results Found";

        [Test]
        public void Constructor_WhenResultsAreNull_SetsNoResultMessage()
        {
            var searchResultViewModel = new SearchResultViewModel(new SearchResultModel(null));

            Assert.AreEqual(NoResultMsg, searchResultViewModel.ResultString);
        }

        [Test]
        public void Constructor_WhenResultsAreEmpty_SetsNoResultMessage()
        {
            var results = new List<int>();
            var searchResultViewModel = new SearchResultViewModel(new SearchResultModel(results));

            Assert.AreEqual(NoResultMsg, searchResultViewModel.ResultString);
        }

        [Test]
        public void Constructor_WhenOneResult_HasOneIntInResult()
        {
            var results = new List<int>{ 99 };
            var searchResultViewModel = new SearchResultViewModel(new SearchResultModel(results));

            Assert.AreEqual("99", searchResultViewModel.ResultString);
        }

        [Test]
        public void Constructor_WhenDefaultSeparator_JoinsIntsTogetherWithDefaultSeparator()
        {
            var results = new List<int> { 1, 2, 3, 4 };
            var searchResultViewModel = new SearchResultViewModel(new SearchResultModel(results));

            Assert.AreEqual("1, 2, 3, 4", searchResultViewModel.ResultString);
        }

        [Test]
        public void Constructor_WhenNullSeparator_JoinsIntsTogether()
        {
            var results = new List<int> { 1, 2, 3, 4 };
            var searchResultViewModel = new SearchResultViewModel(new SearchResultModel(results, null));

            Assert.AreEqual("1234", searchResultViewModel.ResultString);
        }

        [Test]
        public void Constructor_WhenNewSeparator_JoinsIntsTogetherWithNewSeparator()
        {
            var results = new List<int> { 1, 2, 3, 4 };
            var searchResultViewModel = new SearchResultViewModel(new SearchResultModel(results, " "));

            Assert.AreEqual("1 2 3 4", searchResultViewModel.ResultString);
        }
    }
}
