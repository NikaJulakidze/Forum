using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models.Tag
{
    public class TagListingModel
    {
        public string TagTitle { get; set; }
        public string TagContent { get; set; }
        public int TotalQuestionsCount { get; set; }
        public int QuestionsCountThisWeek { get; set; }
        public int QuestionsCountThisYear { get; set; }
        public int QuestionsCountToday { get; set; }

    }
}
