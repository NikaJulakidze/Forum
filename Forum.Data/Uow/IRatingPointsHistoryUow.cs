using Forum.Data.Repository;

namespace Forum.Data.Uow
{
    public interface IRatingPointsHistoryUow:IBaseUow
    {
        IRatingPointsHistoryRepository RatingPointsHistory { get; }
    }
}