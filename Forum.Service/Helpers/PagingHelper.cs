using CommonModels.Paging;
using Forum.Models.Filters;
using Forum.Service.Uri;
using System;
using System.Collections.Generic;

namespace Forum.Service.Helpers
{
    public static class PagingHelper
    {
        public static PagedResult<T> CreatePagedReponse<T>(List<T> pagedData, BaseFilterModel filter, int totalRecords, IUriService uriService, string route)
        {
            var respose = PagedResult<T>.CreatePagedResponse(pagedData, filter.PageNumber, filter.PageSize);

            var totalPages = totalRecords / (double)filter.PageSize;
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            respose.NextPage =
                filter.PageNumber >= 1 && filter.PageNumber < roundedTotalPages
                ? uriService.GetPagedUri(filter.PageNumber + 1, filter.PageSize, route)
                : null;
            respose.PreviousPage =
                filter.PageNumber - 1 >= 1 && filter.PageNumber <= roundedTotalPages
                ? uriService.GetPagedUri(filter.PageNumber - 1, filter.PageSize, route)
                : null;
            respose.FirstPage = uriService.GetPagedUri(1, filter.PageSize, route);
            respose.LastPage = respose.NextPage == null ? null : uriService.GetPagedUri(roundedTotalPages, filter.PageSize, route);
            respose.TotalPages = roundedTotalPages;
            respose.TotalResult = totalRecords;
            return respose;
        }
    }
}
