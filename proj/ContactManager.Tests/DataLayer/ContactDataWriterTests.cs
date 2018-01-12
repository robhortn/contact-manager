using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ContactManager.Data.Models;
using FluentAssertions;

namespace ContactManager.Tests.DataLayer
{
    [TestClass]
    public class ContactDataWriterTests : TestBase
    {
        [TestMethod]
        public void ContactAddTest()
        {
            // Arrange
            Contact param = GenerateContactData();
            Data.DataWriter db = new Data.DataWriter(testmode);

            // Act
            var result = db.AddContact(param);

            // Assert
            result.Should().NotBe(null).And.BeGreaterThan(0).And.BeOfType(typeof(int));
        }

        [TestMethod]
        public void ContactAddTest_BadInsert_MissingData()
        {
            // Arrange
            Contact param = GenerateContactData_BadInsert_MissingData();
            Data.DataWriter db = new Data.DataWriter(testmode);

            // Act
            var result = db.AddContact(param);

            // Assert
            result.Should().Be(0, "we do not expect an ID greater than zero when the insert is bad");
        }

        [TestMethod]
        public void ContactUpdateTest()
        {
            // Arrange
            Contact param = GenerateContactData();
            Data.DataWriter db = new Data.DataWriter(testmode);

            // Act
            var result = db.UpdateContact(param);

            // Assert
            result.Should().Be(param.Id);
        }

        [TestMethod]
        public void ContactUpdateTest_BadUpdate()
        {
            // Arrange
            Contact param = null;
            Data.DataWriter db = new Data.DataWriter(testmode);

            // Act
            var result = db.UpdateContact(param);

            // Assert
            result.Should().Be(0, "when an update fails this is what we need back");
        }
    }
}
