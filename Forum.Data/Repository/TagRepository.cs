using Forum.Data.Constants;
using Forum.Data.Entities;
using Forum.Data.Extensions;
using Forum.Models.Filters;
using Forum.Models.Tag;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Data.Repository
{
    public class TagRepository:BaseRepository<Tag>,ITagRepository
    {
        public TagRepository(ApplicationDbContext context):base(context)
        {

        }

        public List<Tag> GetTagsByNames(List<string> tagNames)
        {
            return _context.Tags.Where(x => tagNames.Contains(x.Title)).ToList();
        }

        public async Task<(List<TagListingModel>,int)> GetTags(BaseFilterModel filterModel)
        {
            var tags = GetFilteredTags(filterModel);
            var totalCount = await tags.CountAsync();
            var result= await tags.Skip((filterModel.PageNumber - 1) * filterModel.PageSize).Take(filterModel.PageSize).ToListAsync();
            return (result, totalCount);
        }


        private IQueryable<Tag> SearchUsers(string searchValue)
        {
            if (!string.IsNullOrWhiteSpace(searchValue))
                return _context.Tags.AsNoTracking().Where(x => x.Content.Contains(searchValue)||x.Title.Contains(searchValue));
            return _context.Tags.AsNoTracking();
        }

        private IQueryable<TagListingModel> GetFilteredTags(BaseFilterModel filterModel)
        {
            var monday = DateTime.Now.Date.GetDayOfWeek(DayOfWeek.Monday);
            var tags = SearchUsers(filterModel.SearchValue);

            var result = tags.Select(x => new TagListingModel
            {
                QuestionsCountToday = x.TagQuestions.Where(x => x.Question.CreatedDate >= DateTime.Today).Count(),
                QuestionsCountThisYear = x.TagQuestions.Where(x => x.Question.CreatedDate >= DateTime.Today.AddYears(-1)).Select(x => x.Question).Count(),
                QuestionsCountThisWeek = x.TagQuestions.Where(x => x.Question.CreatedDate >= DateTime.Today.AddDays(-7)).Count(),
                TotalQuestionsCount=x.TagQuestions.Select(x=>x.Question).Count(),
                TagContent=x.Content,
                TagTitle=x.Title,
            });

            return FilterAndSortTags(result,filterModel.Tab);
        }

        private IQueryable<TagListingModel> FilterAndSortTags(IQueryable<TagListingModel> data, string tab)
        {
            if (string.IsNullOrEmpty(tab))
                return data.OrderByDescending(x => x.TotalQuestionsCount);

            return tab.ToLower() switch
            {
                TabConstants.New => data.OrderBy(x => x.TagTitle),
                TabConstants.Popular => data.OrderByDescending(x => x.TotalQuestionsCount),
                TabConstants.Name => data.OrderBy(x => x.TagTitle),
                _ => data.OrderByDescending(x=>x.TotalQuestionsCount)
            };
        }
    }
}
