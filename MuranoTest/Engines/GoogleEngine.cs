using MuranoTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MuranoTest.Engines
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


    public class GoogleSearchResult
    {
        public string kind { get; set; }
        public Url url { get; set; }
        public Queries queries { get; set; }
        public Context context { get; set; }
        public Searchinformation searchInformation { get; set; }
        public Item[] items { get; set; }
    }

    public class Url
    {
        public string type { get; set; }
        public string template { get; set; }
    }

    public class Queries
    {
        public Request[] request { get; set; }
        public Nextpage[] nextPage { get; set; }
    }

    public class Request
    {
        public string title { get; set; }
        public string totalResults { get; set; }
        public string searchTerms { get; set; }
        public int count { get; set; }
        public int startIndex { get; set; }
        public string inputEncoding { get; set; }
        public string outputEncoding { get; set; }
        public string safe { get; set; }
        public string cx { get; set; }
    }

    public class Nextpage
    {
        public string title { get; set; }
        public string totalResults { get; set; }
        public string searchTerms { get; set; }
        public int count { get; set; }
        public int startIndex { get; set; }
        public string inputEncoding { get; set; }
        public string outputEncoding { get; set; }
        public string safe { get; set; }
        public string cx { get; set; }
    }

    public class Context
    {
        public string title { get; set; }
        public Facet[][] facets { get; set; }
    }

    public class Facet
    {
        public string anchor { get; set; }
        public string label { get; set; }
        public string label_with_op { get; set; }
    }

    public class Searchinformation
    {
        public float searchTime { get; set; }
        public string formattedSearchTime { get; set; }
        public string totalResults { get; set; }
        public string formattedTotalResults { get; set; }
    }

    public class Item
    {
        public string kind { get; set; }
        public string title { get; set; }
        public string htmlTitle { get; set; }
        public string link { get; set; }
        public string displayLink { get; set; }
        public string snippet { get; set; }
        public string htmlSnippet { get; set; }
        public string cacheId { get; set; }
        public string formattedUrl { get; set; }
        public string htmlFormattedUrl { get; set; }
        public Pagemap pagemap { get; set; }
        public Label[] labels { get; set; }
        public string mime { get; set; }
        public string fileFormat { get; set; }
    }

    public class Pagemap
    {
        public Metatag[] metatags { get; set; }
        public Cse_Thumbnail[] cse_thumbnail { get; set; }
        public Cse_Image[] cse_image { get; set; }
    }

    public class Metatag
    {
        public string viewport { get; set; }
        public string moddate { get; set; }
        public string creator { get; set; }
        public string creationdate { get; set; }
        public string fullbanner { get; set; }
        public string producer { get; set; }
        public string author { get; set; }
        public string ogimage { get; set; }
        public string ogtype { get; set; }
        public string twittercard { get; set; }
        public string twittertitle { get; set; }
        public string twittersite { get; set; }
        public string twitterdescription { get; set; }
        public string ogtitle { get; set; }
        public string ogurl { get; set; }
        public string ogdescription { get; set; }
        public string twitterimage { get; set; }
        public string title { get; set; }
    }

    public class Cse_Thumbnail
    {
        public string src { get; set; }
        public string width { get; set; }
        public string height { get; set; }
    }

    public class Cse_Image
    {
        public string src { get; set; }
    }

    public class Label
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public string label_with_op { get; set; }
    }

}
