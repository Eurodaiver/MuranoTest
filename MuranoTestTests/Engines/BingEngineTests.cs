using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuranoTest.Engines;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuranoTest.Engines.Tests
{
    [TestClass()]
    public class BingEngineTests
    {
        [TestMethod()]
        public void SearchAsyncTest_empty_string()
        {
            var str = "";
            var engine = new BingEngine();
            var res = engine.SearchAsync(str);
            Assert.IsInstanceOfType(res, typeof(System.Threading.Tasks.Task<Models.SearchResult>));
        }

        [TestMethod()]
        public void SearchAsyncTest_simple_string()
        {
            var str = "test";
            var engine = new BingEngine();
            var res = engine.SearchAsync(str);
            Assert.IsInstanceOfType(res, typeof(System.Threading.Tasks.Task<Models.SearchResult>));
        }

        [TestMethod()]
        public void SearchAsyncTest_long_string()
        {
            var str = "test one two three";
            var engine = new BingEngine();
            var res = engine.SearchAsync(str);
            Assert.IsTrue(res.Result.results.Count > 0);
        }
    }
}