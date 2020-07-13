using Forum.Data.Entities;

namespace Forum.Data.Repository
{
    public class RatingPointsHistoryRepository:BaseRepository<UserRatingPointsHistory>,IRatingPointsHistoryRepository
    {
        public RatingPointsHistoryRepository(ApplicationDbContext context):base (context)
        {

        }
    }
}
