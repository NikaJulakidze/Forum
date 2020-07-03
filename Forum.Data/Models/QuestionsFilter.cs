using System;

namespace Forum.Data.Models
{
    public class QuestionsFilter
    {
        public int? Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
        public int? TagId { get; set; }
    }
}
