using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MuranoTest.Models
{
    public class GoogleEngine : ISearchEngine
    {
        public async Task<SearchResult> SearchAsync(string SearchText)
        {
            HttpClient client = new HttpClient();
            var res = await client.GetStringAsync("https://www.googleapis.com/customsearch/v1?key=AIzaSyBn38kOVM3fbcJ_i8_JwEUgpJf61dAqPGs&cx=017576662512468239146:omuauf_lfve&q=" + SearchText);
 
            GoogleSearchResult jres = JsonConvert.DeserializeObject<GoogleSearchResult>(res);

            List<SearchResultItem> sres = new List<SearchResultItem>();
            foreach(var item in jres.items)
            {
                sres.Add(new SearchResultItem { Header = item.title, Link = item.displayLink, Url = item.link, Text = item.snippet });
            }

            return new SearchResult { fullText = res, results = sres};
        }
    }
}
