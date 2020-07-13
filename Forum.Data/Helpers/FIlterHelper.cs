using Forum.Data.Constants;
using Forum.Data.Entities;
using Forum.Models.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Forum.Data.Helpers
{
    public static class FIlterHelper
    {
        public async static Task<(List<ApplicationUser>,int)> GetFilteredUsers(this IQueryable<ApplicationUser> users, UsersFilterModel model)
        {
            users = users.SearchUsers(model);
            var count = users.Count();
            return (await users.Skip((model.PageNumber - 1) * model.PageSize).Take(model.PageSize).ToListAsync(), count);
        }

        public static IQueryable<ApplicationUser> SearchUsers(this IQueryable<ApplicationUser> users, UsersFilterModel model)
        {
            if (string.IsNullOrWhiteSpace(model.SearchValue))
                return users.FilterUsers(model);   
            
            else
            {
                users= users.Where(x => x.UserName.Contains(model.SearchValue));
                
                return users.FilterUsers(model);
            }
        }

        public static IQueryable<ApplicationUser> FilterUsers(this IQueryable<ApplicationUser> users,UsersFilterModel model)
        {
            switch (model.Filter.ToLower())
            {
                case FilterConstants.Reputation:
                    return users.OrderByDescending(x=>x.RatingPoints).SubFilterUsers(model.SubFilter);
                case FilterConstants.NewUsers:
                    return users.Where(x => x.RegisterTime >= DateTime.Today.AddMonths(-1));
            }

            return null;
        }
        public static IQueryable<ApplicationUser> SortUsers(this IQueryable<ApplicationUser> users, string sort)
        {
            if (sort == null)
                return users;
            return sort.ToLower() switch
            {
                SortConstants.Reputation => users.OrderByDescending(x => x.RatingPoints),
                SortConstants.CreationTime => users.OrderByDescending(x => x.RegisterTime),
                _ => users.OrderByDescending(x => x.RatingPoints),
            };
        }

        public static IQueryable<ApplicationUser> SubFilterUsers(this IQueryable<ApplicationUser> users, string subFilter)
        {
            if (subFilter == null)
                return users.Where(x => x.RegisterTime >= DateTime.Today.AddDays(-7));

            return subFilter.ToLower() switch
            {
              SubFilterConstatns.Week => users.Where(x => x.RegisterTime >= DateTime.Today.AddDays(-7)),
              SubFilterConstatns.Month => users.Where(x => x.RegisterTime >= DateTime.Today.AddMonths(-1)),
              SubFilterConstatns.Year => users.Where(x => x.RegisterTime >= DateTime.Today.AddYears(-1)),
              SubFilterConstatns.Today => users.Where(x => x.RegisterTime >= DateTime.Today),
              SubFilterConstatns.All=>users,
                _ => users.Where(x => x.RegisterTime >= DateTime.Today.AddDays(-7)),
            };
        }
    }
}
