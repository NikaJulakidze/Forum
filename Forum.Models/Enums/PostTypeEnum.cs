using System.Runtime.Serialization;

namespace Forum.Models.Enums
{
    public enum PostTypeEnum
    {
        [EnumMember(Value = "Question")]
        Question=1,
        [EnumMember(Value = "Answer")]
        Answer=2
    }
}
