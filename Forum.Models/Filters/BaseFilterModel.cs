using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models.Filters
{
    public class BaseFilterModel
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public string SearchValue { get; set; }
    }
}
