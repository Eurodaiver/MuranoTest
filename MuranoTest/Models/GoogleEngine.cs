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
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var res = await client.GetStringAsync("https://www.googleapis.com/customsearch/v1?key=AIzaSyBn38kOVM3fbcJ_i8_JwEUgpJf61dAqPGs&cx=017576662512468239146:omuauf_lfve&q=" + SearchText);

                    GoogleSearchResult jres = JsonConvert.DeserializeObject<GoogleSearchResult>(res);

                    List<SearchResultItem> listResults = new List<SearchResultItem>();

                    if (jres.items != null)
                    {
                        foreach (var item in jres.items)
                        {
                            listResults.Add(new SearchResultItem { Header = item.title, Link = item.displayLink, Url = item.link, Text = item.snippet });
                        }
                    }

                    return new SearchResult { fullText = res, results = listResults };
                }
                catch (Exception ex)
                {
                    return new SearchResult { fullText = "ERROR: " + ex.Data, results = null };
                }
            }                              
            
        }
    }
}
