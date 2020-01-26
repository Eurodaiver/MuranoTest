using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuranoTest.Models
{
    public class SearchContext : DbContext
    {
        public DbSet<SearchResultItem> searchResultItems { get; set; }

        public SearchContext(DbContextOptions<SearchContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
