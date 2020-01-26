using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuranoTest.Controllers;
using MuranoTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuranoTest.Controllers.Tests.Controllers
{
    [TestClass()]
    public class HomeControllerTests
    {
        private readonly SearchContext _context;

        [TestMethod()]
        public void IndexAsyncTest()
        {
            HomeController controller = new HomeController(_context);

            ViewResult result = controller.IndexAsync("test").Result as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsTrue(((SearchResultsViewModel)result.Model).resultItems.Count > 0);
        }


        [TestMethod()]
        public void LocalSearchAsyncTest()
        {
            HomeController controller = new HomeController(_context);

            ViewResult result = controller.IndexAsync("test").Result as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsTrue(((SearchResultsViewModel)result.Model).resultItems.Count > 0);
        }
    }
}