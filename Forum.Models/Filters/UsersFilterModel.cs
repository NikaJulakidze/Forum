namespace Forum.Models.Filters
{
    public class UsersFilterModel:BaseFilterModel
    {
        public string Sort { get; set; }
        public string Filter { get; set; }
        public string SubFilter { get; set; }
    }
}
