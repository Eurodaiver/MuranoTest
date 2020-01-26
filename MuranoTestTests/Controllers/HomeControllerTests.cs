using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        DbContextOptions<SearchContext> options = new DbContextOptionsBuilder<SearchContext>()
         .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=murano1_db;Trusted_Connection=True;MultipleActiveResultSets=true")
         .Options;


        [TestMethod()]
        public void IndexAsyncTest()
        {
            HomeController controller = new HomeController(new SearchContext(options));

            ViewResult result = controller.IndexAsync("test").Result as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsTrue(((SearchResultsViewModel)result.Model).resultItems.Count > 0);
        }


        [TestMethod()]
        public void LocalSearchTest()
        {
            HomeController controller = new HomeController(new SearchContext(options));

            ViewResult result = controller.LocalSearch("test") as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsTrue(((SearchResultsViewModel)result.Model).resultItems.Count > 0);
        }
    }
}