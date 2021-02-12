namespace Forum.Models.Filters
{
    public class BaseFilterModel
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string SearchValue { get; set; }
        public string Tab { get; set; }
        public string Filter { get; set; }
        public string Sort { get; set; }
    }
}
