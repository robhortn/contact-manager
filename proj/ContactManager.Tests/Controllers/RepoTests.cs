using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;
using System.Collections.Generic;
using ContactManager.Data;
using ContactManager.Data.Models;
using FluentAssertions;

namespace ContactManager.Tests.Controllers
{
    [TestClass]
    public class RepoTests
    {
        [TestMethod]
        public void RepoLookupsGetStateProvincesTest()
        {
            RepoLookups repo = new RepoLookups();
            var results = repo.GetStateProvinces.ToList();
            results.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void RepoLookupsGetCategoriesTest()
        {
            RepoLookups repo = new RepoLookups();
            var results = repo.GetCategories.ToList();
            results.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void RepoGetCompaniesTest()
        {
            RepoCompanies repo = new RepoCompanies();
            var results = repo.GetCompanies.ToList();
            results.Should().NotBeNullOrEmpty();
        }
    }
}
