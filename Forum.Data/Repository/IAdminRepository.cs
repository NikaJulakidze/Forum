using Forum.Data.Entities;
using System.Threading.Tasks;

namespace Forum.Data.Repository
{
    public interface IAdminRepository
    {
        Task CreatePostType(PostType postType);
        void CreateTag(Tag tag);
        void DeleteTag(Tag tag);
        void EditTag(Tag tag);
    }
}
