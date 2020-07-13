using Forum.Data.Entities;

namespace Forum.Data.Repository
{
    public interface IAdminRepository
    {
        void CreateTag(Tag tag);
        void DeleteTag(Tag tag);
        void EditTag(Tag tag);
    }
}
