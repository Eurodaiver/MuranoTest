using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MuranoTest.Engines.Tests
{
    [TestClass()]
    public class YandexEngineTests
    {
        [TestMethod()]
        public void SearchAsyncTest_empty_string()
        {
            var str = "";
            var engine = new YandexEngine();
            var res = engine.SearchAsync(str);
            Assert.IsInstanceOfType(res, typeof(System.Threading.Tasks.Task<Models.SearchResult>));
        }

        [TestMethod()]
        public void SearchAsyncTest_simple_string()
        {
            var str = "test";
            var engine = new YandexEngine();
            var res = engine.SearchAsync(str);
            Assert.IsInstanceOfType(res, typeof(System.Threading.Tasks.Task<Models.SearchResult>));
            Assert.IsTrue(res.Result.results.Count > 0);
        }


    }
}