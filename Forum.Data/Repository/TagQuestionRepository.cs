using Forum.Data.Entities;
using System.Collections.Generic;

namespace Forum.Data.Repository
{
    public class TagQuestionRepository:ITagQuestionRepository
    {
        private readonly ApplicationDbContext _context;

        public TagQuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddRange(List<TagQuestion> tagQuestions)
        {
            _context.AddRange(tagQuestions);
        }
    }
}
