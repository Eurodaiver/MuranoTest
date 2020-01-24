using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuranoTest.Models
{
    interface ISearchEngine
    {
        Task<SearchResult> SearchAsync(string SearchText);

    }


}
