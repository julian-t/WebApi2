using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi2.Models;
using WebApi2.Controllers;
using System.Web.Http.Results;

namespace WebApi2.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AdditionWorks()
        {
            // The simplest test
            int n = 2 + 2;
            Assert.AreEqual(4, n);
        }

        [TestMethod]
        public void TestTraderGet()
        {
            // Test method that returns a string
            var controller = new TradesController();

            var response = controller.Get("fred");
            Assert.AreEqual("GET for trader fred", response);
        }

        [TestMethod]
        public void TestResponse()
        {
            // Test a method that returns an IHttpActionResult
            var controller = new TradesController();

            // OkNegotiatedContentResult is used to handle a 200 OK with content
            var response = controller.Get(3);
            var result = response as OkNegotiatedContentResult<Trade>;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(1000, result.Content.Volume);
        }
    }
}
