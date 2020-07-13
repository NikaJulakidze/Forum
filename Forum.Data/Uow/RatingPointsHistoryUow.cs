using Forum.Data.Repository;

namespace Forum.Data.Uow
{
    public class RatingPointsHistoryUow:BaseUow,IRatingPointsHistoryUow
    {
        public RatingPointsHistoryUow(ApplicationDbContext context, IRatingPointsHistoryRepository  ratingPointsHistory):base(context)
        {
            RatingPointsHistory = ratingPointsHistory;
        }
        public IRatingPointsHistoryRepository  RatingPointsHistory { get; }
    }
}
