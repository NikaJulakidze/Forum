using Forum.Data.Entities;
using Forum.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Forum.Data.Helpers
{
    public class FIlterHelper
    {
        public static void FilterQuestions(IQueryable<Question> source,  QuestionsFilter questionFiler)
        {
            if (!string.IsNullOrWhiteSpace(questionFiler.Title))
                source = source.Where(x => x.Title.Contains(questionFiler.Title));

        }

        public static IQueryable<ApplicationUser> GetFilteredUsers(IQueryable<ApplicationUser> users,UsersFilterModel filter)
        {
            //if (UsersFilterModel.HaveFilter(filter))
            //{
            //    if (!string.IsNullOrEmpty(filter.SearchString))
            //        users = users.Where(x => x.UserName.Contains(filter.SearchString));
            //}
            return null;
        }
    }
}
