using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using PenAndPaper.Controllers;
using System;

namespace PenAndPaper.NUnit
{
    [TestFixture]
    public class HomeControllerTest
    {
        [SetUp]
        public void TestInit() { }

        [TearDown]
        public void TestTeardown() { }

        [Test]
        [Category("Controller")]
        public void HomeIndexTest()
        {
            var controller = new HomeController();

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
