using MyBlog.Data;
using MyBlog.Repository.Interfaces;
using System.Linq;

namespace MyBlog.Repository
{
    public class BlogLikeRepository : IBlogLikeRepository
    {
        private MyBlogsContext Context { get; set; }
        public BlogLikeRepository(MyBlogsContext context)
        {
            Context = context;
        }

        public void Add(BlogLike blogLike)
        {
            Context.BlogLikes.Add(blogLike);
            Context.SaveChanges();
        }

        public BlogLike Get(int blogId, int userId)
        {
            return Context.BlogLikes.FirstOrDefault(x => x.BlogId == blogId && x.UserId == userId);
        }

        public void Remove(BlogLike blogLike)
        {
            Context.BlogLikes.Remove(blogLike);
            Context.SaveChanges();
        }

        public void Update(BlogLike like)
        {
            Context.BlogLikes.Update(like);
            Context.SaveChanges();
        }
    }
}
