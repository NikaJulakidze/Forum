using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Models
{
    public class PagedList<T>:List<T>
    {
        public PagedList(List<T> source, int count,int currentPage, int pageSize)
        {
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(source);
        }


        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
     


        public bool HasPreviousPage
        {
            get { return CurrentPage > 1; }
        }
        public bool HasNexPage
        {
            get { return CurrentPage < TotalPages; }
        }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
