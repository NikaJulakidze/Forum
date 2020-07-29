using Forum.Models.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Service.Uri
{
    public interface IUriService
    {
        System.Uri GetPagedUri(int pageNumber, int pageSize, string route);
    }
}
