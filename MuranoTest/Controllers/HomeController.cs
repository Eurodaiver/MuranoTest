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
                bing.SearchAsync(TextRequest),
                google.SearchAsync(TextRequest),
                yandex.SearchAsync(TextRequest)
                
            };

            //when the first task was completed
            Task<SearchResult> finished = await Task.WhenAny(allTasks);
            allTasks.Clear();

            SearchResult res = await finished;
            var limitedList = res.results.Take(10).ToList();
            //save top 10 results
            foreach (var r in limitedList)
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

            SearchResultsViewModel resultsViewModel = new SearchResultsViewModel { resultItems = limitedList, fullText = (limitedList.Count == 0)? "Nothing found" : null };

            return View(resultsViewModel);
        }



        [HttpGet]
        public IActionResult LocalSearch()
        {
            return View();
        }

        //Searching in our database
        [HttpPost]
        public IActionResult LocalSearch(string TextRequest)
        {
            //as sample search in headers
            var res = _context.searchResultItems.Where(x => x.Header.Contains(TextRequest)).Take(10).ToList();

            var resultsViewModel = new SearchResultsViewModel { resultItems = res, fullText = (res.Count == 0) ? "Nothing found" : null };

            return View(resultsViewModel);

        }
    }
}
