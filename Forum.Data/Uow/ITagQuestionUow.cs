using Forum.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Data.Uow
{
    public interface ITagQuestionUow : IBaseUow
    {
        ITagQuestionRepository TagQuestionRepository { get; }
    }
}
