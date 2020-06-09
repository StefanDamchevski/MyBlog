using Microsoft.EntityFrameworkCore;

namespace MyBlog.Data
{
    public class MyBlogsContext:DbContext
    {
        public MyBlogsContext(DbContextOptions<MyBlogsContext> options) : base(options)
        {
        }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<BlogComment> BlogComments { get; set; }
    }
}
