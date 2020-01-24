using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MuranoTest.Models;

namespace MuranoTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(string TextRequest)
        {
            var google = new GoogleEngine();
            var google2 = new GoogleEngine();

            var allTasks = new List<Task<SearchResult>> { google.SearchAsync(TextRequest), google2.SearchAsync(TextRequest)};//добавить нужную реализацию поиска в список

            Task<SearchResult> finished = await Task.WhenAny(allTasks);
            allTasks.Clear();
                       
            SearchResult res = await finished;



            ViewBag.searchResults = new SearchResultsViewModel { resultItems = res.results, fullText = res.fullText }; //выбрать только результаты из нужных полей для вывода в таблицу во вью


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
