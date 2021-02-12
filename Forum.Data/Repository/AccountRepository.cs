using AutoMapper;
using AutoMapper.QueryableExtensions;
using Forum.Data.Constants;
using Forum.Data.Entities;
using Forum.Data.Extensions;
using Forum.Models.Account;
using Forum.Models.ApplicationUser;
using Forum.Models.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Forum.Data.Repository
{
    public class AccountRepository : BaseRepository<ApplicationUser>, IAccountRepository
    {
        private readonly IMapper _mapper;
        private readonly IConfigurationProvider _configuration;
        public AccountRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
            _configuration = mapper.ConfigurationProvider;
        }

        public async Task<List<ApplicationUser>> GetHappyBirthDayUsers()
        {
            return await _context.ApplicationUsers.ToListAsync();
        }

        public async Task<(List<ApplicationUser>, int)> GetFilteredUsers(UsersFilterModel filter)
        {
            var users = _context.ApplicationUsers.AsNoTracking();
            //var result = SearchUsers(users, filter);
            return (await users.ToListAsync(), await users.CountAsync());
        }

        public async Task<UserProfileModel> GetByIdAsync (string id)
        {
            return await _context.ApplicationUsers.Where(x => x.Id == id)
                .Include(x => x.Posts).ProjectTo<UserProfileModel>(_configuration).FirstAsync();
        }


        public async Task<ApplicationUserTopPosts> TopPosts(string id)
        {
            var monday = DateTime.Now.GetDayOfWeek(DayOfWeek.Monday);
            
            return null;
        }


        public async Task<List<ApplicationUserTop15>> GetTop15UsersThisWeek()
        {
            var monday = DateTime.Now.GetDayOfWeek(DayOfWeek.Monday);
            return null;
        }

        public async Task<List<ApplicationUser>> GetTop15ForGift()
        {
            return null;
        }

        public void BulkUpdate(List<ApplicationUser> users)
        {
            _context.ApplicationUsers.UpdateRange(users);
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
            var monday = DateTime.Now.GetDayOfWeek(DayOfWeek.Monday);
            //switch (model.Tab?.ToLower())
            //{
            //    case TabConstants.Reputation:    
            //        return SubFilterUsers(users,model);
            //    case TabConstants.NewUsers:
            //         users.Where(x => x.RegisterTime >= DateTime.Today.AddMonths(-1));
            //        return SortUserss(users, model.Sort);
            //    case null:
            //        var aaa = users.Select(x => new ApplicationUser 
            //        {
            //            RatingPoints=x.UserRatingPoints.Where(x=>x.AddedTime>=monday).Sum(x=>x.RatingPoints)
            //        });
            //        return SubFilterUsers(users, model);
            //    default:
            //        return null;
            //}
            return null;
        }
        private IQueryable<ApplicationUser> SubFilterUsers(IQueryable<ApplicationUser> users,UsersFilterModel model)
        {
            switch (model.Filter?.ToLower())
            {
                case FilterConstatns.All:
                    return SortUserss(users,SortConstants.Reputation);
                case FilterConstatns.Year:
                    users.Where(x => x.RatingPointsHistory.Select(x => x.AddedTime >= DateTime.Today.AddYears(-1)).LastOrDefault());
                    return SortUserss(users,SortConstants.Reputation);
                case FilterConstatns.Month:
                     users.Where(x => x.RatingPointsHistory.Select(x=>x.AddedTime>=DateTime.Today.AddMonths(-1)).LastOrDefault());
                    return SortUserss(users, SortConstants.Reputation);
                case FilterConstatns.Week:
                    users.Where(x => x.RatingPointsHistory.Select(x => x.AddedTime >= DateTime.Today.AddDays(-7)).LastOrDefault());
                    return SortUserss(users, SortConstants.Reputation);
                case FilterConstatns.Today:
                    users.Where(x => x.RatingPointsHistory.Select(x => x.AddedTime >= DateTime.Today).FirstOrDefault()); ;
                    return SortUserss(users, SortConstants.Reputation);
            }
            users = users.Where(x => x.RatingPointsHistory.Select(x => x.AddedTime >= DateTime.Today.AddDays(-7)).LastOrDefault());
            return SortUserss(users, SortConstants.Reputation);
        }
        private IQueryable<ApplicationUser> SortUserss(IQueryable<ApplicationUser> users,string sortOrder)
        {
            switch (sortOrder)
            {
                case SortConstants.CreationTime:
                    users.OrderBy(x => x.MemberSince);
                    return users;
                case SortConstants.Reputation:
                    return users.OrderByDescending(x=>x.RatingPoints);
            }
            return null;
        }
    }
}
