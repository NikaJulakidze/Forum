using System.Runtime.Serialization;

namespace Forum.Models.PostType
{
    public enum PostTypeEnum
    {
        [EnumMember(Value = "Question")]
        Question,
        [EnumMember(Value = "Answer")]
        Answer
    }
}
