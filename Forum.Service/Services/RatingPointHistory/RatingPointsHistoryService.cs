using Forum.Data.Entities;
using Forum.Data.Repository;
using Forum.Data.UnitOfWork;

namespace Forum.Service.Services.RatingPointHistory
{
    public class RatingPointsHistoryService: IRatingPointsHistoryService
    {
        private readonly IRatingPointsHistoryRepository _ratingPoints;
        private readonly IUnitOfWork _unitOfWork;

        public RatingPointsHistoryService(IRatingPointsHistoryRepository ratingPoints,IUnitOfWork unitOfWork)
        {
            _ratingPoints = ratingPoints;
            _unitOfWork = unitOfWork;
        }

        public void Add(UserRatingPointsHistory history)
        {
            _ratingPoints.Add(history);
        }
    }
}
