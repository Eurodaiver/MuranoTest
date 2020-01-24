using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuranoTest.Models
{
    public class SearchResult
    {
        public string fullText { get; set; }
        public List<SearchResultItem> results { get; set; }
    }


    public class SearchResultItem
    {
        public string Header { get; set; }
        public string Link { get; set; }
        public string Url { get; set; }
        public string Text { get; set; }
    }
}
