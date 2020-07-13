namespace Forum.Service.Models
{
    public class PagedList<T> where T : class
    {
        //public PagedList(List<T> source,PagingSettings pagingSettings)
        //{
        //    this.Source = source;
        //    this.PagingSettings = pagingSettings;   
        //}

        //public PagingSettings PagingSettings { get; private set; }

        //public List<T> Source { get; private set; }

        //public bool HasNextPage => PagingSettings.CurrentPage < PagingSettings.TotalPage;
        //public bool HasPreviousPage => PagingSettings.CurrentPage > 1;


        //public static PagedList<T> CreatePaging(List<T> source,PagingSettings pagingSettings) => new PagedList<T>(source,pagingSettings) { Source = source, PagingSettings = pagingSettings };


        //public PagedList(List<T> source, int count,int currentPage, int pageSize)
        //{
        //    CurrentPage = currentPage;
        //    TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        //    this.AddRange(source);
        //}


        //public int CurrentPage { get; private set; }
        //public int TotalPages { get; private set; }
     


        //public bool HasPreviousPage
        //{
        //    get { return CurrentPage > 1; }
        //}
        //public bool HasNexPage
        //{
        //    get { return CurrentPage < TotalPages; }
        //}

        //public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        //{
        //    var count = await source.CountAsync();
        //    var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        //    return new PagedList<T>(items, count, pageNumber, pageSize);
        //}
    }
}
