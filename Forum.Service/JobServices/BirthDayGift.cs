using Forum.Data;

namespace Forum.Service.JobServices
{
    public class BirthDayGift:IBirthDayGift
    {
        private readonly ApplicationDbContext _context;

        public BirthDayGift(ApplicationDbContext context)
        {
            _context = context;
        }

    }
}
