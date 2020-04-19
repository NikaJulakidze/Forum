using System.Threading.Tasks;

namespace Forum.Data.Uow
{
    public class BaseUow:IBaseUow
    {
        private readonly ApplicationDbContext _context;

        public BaseUow(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
