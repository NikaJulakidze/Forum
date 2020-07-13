using Forum.Data.Constants;
using Forum.Data.Entities;
using Forum.Models.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Forum.Data.Repository
{
    public class AccountRepository : BaseRepository<ApplicationUser>, IAccountRepository
    {
        public AccountRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<(List<ApplicationUser>, int)> GetFilteredUsers(UsersFilterModel filter)
        {
            var result = SearchUsers(_entity.Include(x=>x.UserRatingPoints).AsNoTracking().AsQueryable(), filter);
            return (await result.ToListAsync(), await result.CountAsync());
        }

        public override async Task<ApplicationUser> GetByIdAsync<T>(T id)
        {
            var result = await _entity
                                      .Include(x => x.Questions)
                                      .ThenInclude(x=>x.TagQuestions)
                                      .ThenInclude(x=>x.Tag)
                                      .Include(x => x.UserRatingPoints)
                                      .FirstOrDefaultAsync(x=>x.Id==id.ToString());
            return result;
        }

        private IQueryable<ApplicationUser> SearchUsers(IQueryable<ApplicationUser> users, UsersFilterModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.SearchValue))
                users = users.Where(x => x.UserName.Contains(model.SearchValue));
            if (users.Count() == 0)
                return null;
            return FilterUsers(users,model);
        }

        private IQueryable<ApplicationUser> FilterUsers(IQueryable<ApplicationUser> users,UsersFilterModel model)
        {
            switch (model.Filter?.ToLower())
            {
                case FilterConstants.Reputation:    
                    return SubFilterUsers(users,model);
                case FilterConstants.NewUsers:
                     users.Where(x => x.RegisterTime >= DateTime.Today.AddMonths(-1));
                    return SortUserss(users, model.Sort);
                case null:
                    users = users.Where(x => x.UserRatingPoints.Select(x => x.AddedTime >= DateTime.Today.AddDays(-7)).LastOrDefault());
                    return SubFilterUsers(users, model);
                default:
                    return null;
            }
        }
        private IQueryable<ApplicationUser> SubFilterUsers(IQueryable<ApplicationUser> users,UsersFilterModel model)
        {
            switch (model.SubFilter?.ToLower())
            {
                case SubFilterConstatns.All:
                    return SortUserss(users,SortConstants.Reputation);
                case SubFilterConstatns.Year:
                    users.Where(x => x.UserRatingPoints.Select(x => x.AddedTime >= DateTime.Today.AddYears(-1)).LastOrDefault());
                    return SortUserss(users,SortConstants.Reputation);
                case SubFilterConstatns.Month:
                     users.Where(x => x.UserRatingPoints.Select(x=>x.AddedTime>=DateTime.Today.AddMonths(-1)).LastOrDefault());
                    return SortUserss(users, SortConstants.Reputation);
                case SubFilterConstatns.Week:
                    users.Where(x => x.UserRatingPoints.Select(x => x.AddedTime >= DateTime.Today.AddDays(-7)).LastOrDefault());
                    return SortUserss(users, SortConstants.Reputation);
                case SubFilterConstatns.Today:
                    users.Where(x => x.UserRatingPoints.Select(x => x.AddedTime >= DateTime.Today).FirstOrDefault()); ;
                    return SortUserss(users, SortConstants.Reputation);
            }
            users = users.Where(x => x.UserRatingPoints.Select(x => x.AddedTime >= DateTime.Today.AddDays(-7)).LastOrDefault());
            return SortUserss(users, SortConstants.Reputation);
        }
        private IQueryable<ApplicationUser> SortUserss(IQueryable<ApplicationUser> users,string sortOrder)
        {
            switch (sortOrder)
            {
                case SortConstants.CreationTime:
                    users.OrderBy(x => x.RegisterTime);
                    return users;
                case SortConstants.Reputation:
                    return users.OrderByDescending(x=>x.RatingPoints);
            }
            return null;
        }
    }
}
