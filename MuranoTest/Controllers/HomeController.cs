using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MuranoTest.Engines;
using MuranoTest.Models;

namespace MuranoTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly SearchContext _context;
        public HomeController(SearchContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(string TextRequest)
        {
            //create instances of engines
            var google = new GoogleEngine();
            var yandex = new YandexEngine();
            var bing = new BingEngine();

            //create a list of instances to execute them at the same time
            var allTasks = new List<Task<SearchResult>> {
                google.SearchAsync(TextRequest),
                yandex.SearchAsync(TextRequest),
                bing.SearchAsync(TextRequest)
            };

            //when the first task was completed
            Task<SearchResult> finished = await Task.WhenAny(allTasks);
            allTasks.Clear();

            SearchResult res = await finished;

            //save top 10 results
            foreach (var r in res.results.Take(10))
            {
                try
                {
                    await _context.searchResultItems.AddAsync(r);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            SearchResultsViewModel resultsViewModel = new SearchResultsViewModel { resultItems = res.results.Take(10).ToList(), fullText = res.fullText };

            return View(resultsViewModel);
        }



        [HttpGet]
        public IActionResult LocalSearch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LocalSearch(string TextRequest)
        {

            var res = _context.searchResultItems.Where(x => x.Header.Contains(TextRequest)).ToList();

            var resultsViewModel = new SearchResultsViewModel { resultItems = res };

            return View(resultsViewModel);

        }
    }
}
