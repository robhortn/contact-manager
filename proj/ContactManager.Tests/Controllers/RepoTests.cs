using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;
using ContactManager.Data;
using FluentAssertions;

namespace ContactManager.Tests.Controllers
{
    [TestClass]
    public class RepoTests
    {
        [TestMethod]
        public void RepoGetCompaniesTest()
        {
            RepoCompanies repo = new RepoCompanies();
            var results = repo.GetCompanies.ToList();
            results.Should().NotBeNullOrEmpty();
        }
    }
}
