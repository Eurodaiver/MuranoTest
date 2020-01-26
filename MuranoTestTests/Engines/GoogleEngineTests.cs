using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuranoTest.Engines;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuranoTest.Engines.Tests
{
    [TestClass()]
    public class GoogleEngineTests
    {
        [TestMethod()]
        public void SearchAsyncTest_empty_string()
        {
            var str = "";
            var engine = new GoogleEngine();
            var res = engine.SearchAsync(str);
            Assert.IsInstanceOfType(res, typeof(System.Threading.Tasks.Task<Models.SearchResult>));

        }

        [TestMethod()]
        public void SearchAsyncTest_simple_string()
        {
            var str = "test";
            var engine = new GoogleEngine();
            var res = engine.SearchAsync(str);
            Assert.IsInstanceOfType(res, typeof(System.Threading.Tasks.Task<Models.SearchResult>));
            Assert.IsTrue(res.Result.results.Count > 0);
        }


    }
}