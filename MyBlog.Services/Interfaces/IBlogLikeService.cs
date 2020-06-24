namespace MyBlog.Service.Interfaces
{
    public interface IBlogLikeService
    {
        void AddLike(int blogId, int userId);
        void RemoveLike(int blogId, int userId);
        void AddDislike(int blogId, int userId);
    }
}
