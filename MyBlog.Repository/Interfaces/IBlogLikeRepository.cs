using MyBlog.Data;

namespace MyBlog.Repository.Interfaces
{
    public interface IBlogLikeRepository
    {
        void Add(BlogLike blogLike);
        BlogLike Get(int blogId, int userId);
        void Remove(BlogLike blogLike);
        void Update(BlogLike like);
    }
}
