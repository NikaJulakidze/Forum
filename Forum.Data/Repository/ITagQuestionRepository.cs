﻿using Forum.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Data.Repository
{
    public interface ITagQuestionRepository
    {
        void AddRange(List<TagPost> tagQuestions);
    }
}
