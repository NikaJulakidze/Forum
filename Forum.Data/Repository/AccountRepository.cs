using Forum.Data.Constants;
using Forum.Data.Entities;
using Forum.Data.Extensions;
using Forum.Models.ApplicationUser;
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

        public override async Task<ApplicationUser> GetByIdAsync<T>(T id)
        {
            var bbb = await _context.ApplicationUsers.Select(x => new
            {
                Answers = x.Answers.OrderByDescending(x=>x.RatingPoints).Take(10),
                Questions = x.Questions.OrderByDescending(x => x.RatingPoints).Take(10),
                PostsCount=x.Answers.Count()+x.Questions.Count(),
                x.Id

            }).FirstAsync(x=>x.Id==id.ToString());
            
            return null;
        }


        public async Task<ApplicationUserTopPosts> TopPosts(string id)
        {
            var monday = DateTime.Now.GetDayOfWeek(DayOfWeek.Monday);

            var aaaaaa = await _context.ApplicationUsers.Where(x => x.Id == id).Select(x => new
            {
                TopTags = x.Answers.Select(x=>x.TagAnswers.Select(x=>x.Tag.Content))

            }).FirstAsync();

            var aaaaaaaaaa = _context.ApplicationUsers.Include(x=>x.Answers).ThenInclude(x=>x.TagAnswers).ThenInclude(x=>x.Tag).First(x => x.Id == id);

            var topTags = aaaaaaaaaa.Answers.GroupBy(x => x.TagAnswers.Select(x => x.Tag.Content));

            var test111 = _context.Tags.Select(x => new
            {
                TopTags = x.TagAnswers.Where(x => x.Answer.UserId == id).Select(x => x.Tag.Content)

            }).ToList();

            var test1 = _context.TagAnswers.
                Where(x => x.Answer.UserId == id).
                Select(x => new
                {
                    TopTags = x.Tag.TagAnswers,
                    Count = x.Tag.TagAnswers.Count()

                }).OrderByDescending(x => x.Count).Take(5).ToList();

            var test = _context.Answers.
                Where(x=>x.UserId==id).Select(x => new
            {
                    TopTags = x.TagAnswers,
                    x.User.UserName,
                    x.User.RatingPoints
            }).ToList();
            
            return null;
        }


        public async Task<List<ApplicationUser>> GetTop15UsersThisWeek()
        {
            var monday = DateTime.Now.GetDayOfWeek(DayOfWeek.Monday);

            var users = _context.ApplicationUsers
                .Select(users => new ApplicationUser
                {
                    UserName = users.UserName,
                    Id = users.Id,
                    Email = users.Email,
                    ImageUrl = users.ImageUrl,
                    RatingPoints = users.UserRatingPoints.Where(x => x.AddedTime >= monday).Sum(x => x.RatingPoints)
                }).
                OrderByDescending(x=>x.RatingPoints).Take(15);

            return await users.ToListAsync();
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
            switch (model.Tab?.ToLower())
            {
                case TabConstants.Reputation:    
                    return SubFilterUsers(users,model);
                case TabConstants.NewUsers:
                     users.Where(x => x.RegisterTime >= DateTime.Today.AddMonths(-1));
                    return SortUserss(users, model.Sort);
                case null:
                    var aaa = users.Select(x => new ApplicationUser 
                    {
                        RatingPoints=x.UserRatingPoints.Where(x=>x.AddedTime>=monday).Sum(x=>x.RatingPoints)
                    });
                    return SubFilterUsers(users, model);
                default:
                    return null;
            }
        }
        private IQueryable<ApplicationUser> SubFilterUsers(IQueryable<ApplicationUser> users,UsersFilterModel model)
        {
            switch (model.Filter?.ToLower())
            {
                case FilterConstatns.All:
                    return SortUserss(users,SortConstants.Reputation);
                case FilterConstatns.Year:
                    users.Where(x => x.UserRatingPoints.Select(x => x.AddedTime >= DateTime.Today.AddYears(-1)).LastOrDefault());
                    return SortUserss(users,SortConstants.Reputation);
                case FilterConstatns.Month:
                     users.Where(x => x.UserRatingPoints.Select(x=>x.AddedTime>=DateTime.Today.AddMonths(-1)).LastOrDefault());
                    return SortUserss(users, SortConstants.Reputation);
                case FilterConstatns.Week:
                    users.Where(x => x.UserRatingPoints.Select(x => x.AddedTime >= DateTime.Today.AddDays(-7)).LastOrDefault());
                    return SortUserss(users, SortConstants.Reputation);
                case FilterConstatns.Today:
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
