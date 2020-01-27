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
         .UseSqlServer("Server=tcp:muranodbserver.database.windows.net,1433;Initial Catalog=muranodb;Persist Security Info=False;User ID=daiver777;Password=Aok96ymV;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
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