using System;
using System.Collections.Generic;

namespace Forum.Models.Paging
{
    public class PagedResult<T>
    {
        public List<T> Data { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalResult { get; set; }
        public Uri NextPage { get; set; }
        public Uri PreviousPage { get; set; }
        public Uri FirstPage { get; set; }
        public Uri LastPage { get; set; }

        public static PagedResult<T> CreatePagedResponse(List<T> Data, int pageNumber, int perPage) => new PagedResult<T> { PageSize =perPage, PageNumber = pageNumber, Data = Data };

    }
}
