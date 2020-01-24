using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuranoTest.Models
{
    public class SearchResultsViewModel
    {
        public string fullText { get; set; }
        public List<SearchResultItem> resultItems { get; set; }
    }

}
