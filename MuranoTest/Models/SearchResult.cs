using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuranoTest.Models
{
    //model for search engines response 
    public class SearchResult
    {
        public string fullText { get; set; }
        public List<SearchResultItem> results { get; set; }
    }


    public class SearchResultItem
    {
        [Key]
        public string Header { get; set; }
        public string Link { get; set; }
        public string Url { get; set; }
        public string Text { get; set; }
    }
}
