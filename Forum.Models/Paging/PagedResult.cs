using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Forum.Models.Paging
{
    public class PagedResult<T>:Result<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalResult { get; set; }


        public static PagedResult<T> CreatePagedResponse(T Data,int totalResult,int pageNumber,int perPage) => new PagedResult<T> { TotalResult=totalResult, PageSize=(int)Math.Ceiling(totalResult/(double)perPage), PageNumber=pageNumber,Data=Data};

    }
}
