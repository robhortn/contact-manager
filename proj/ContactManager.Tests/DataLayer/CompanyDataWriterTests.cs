﻿using System;
using ContactManager.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;
namespace ContactManager.Tests.DataLayer
{
    [TestClass]
    public class CompanyDataWriterTests : TestBase
    {
        [TestMethod]
        public void CompanyAddTest()
        {
            // Arrange
            Company param = GenerateCompanyData();
            Data.DataWriter db = new Data.DataWriter(runInTestMode);

            // Act
            var result = db.AddCompany(param);

            // Assert
            result.Should().NotBe(null).And.BeGreaterThan(0).And.BeOfType(typeof(int));
        }

        [TestMethod]
        public void CompanyUpdateTest()
        {
            // Arrange
            Company param = GenerateCompanyData();
            Data.DataWriter db = new Data.DataWriter(runInTestMode);

            // Act
            var result = db.UpdateCompany(param);

            // Assert
            result.Should().Be(param.Id);
        }

        [TestMethod]
        public void CompanyUpdateTest_Fail()
        {
            // Arrange
            Company param = GenerateCompanyData_BadUpdate();
            Data.DataWriter db = new Data.DataWriter(runInTestMode);

            // Act
            var result = db.UpdateCompany(param);

            // Assert
            result.Should().NotBe(param.Id);
        }

        [TestMethod]
        public void CompanyDeleteTest()
        {
            // Arrange
            Company param = GenerateCompanyData();
            Data.DataWriter db = new Data.DataWriter(runInTestMode);

            // Act
            var result = db.DeleteCompany(param);

            // Assert
            result.Should().Be(true, "it should return True when a record is removed");
        }
    }
}
