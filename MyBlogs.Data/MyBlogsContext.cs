using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Data
{
    public class MyBlogsContext:DbContext
    {
        public MyBlogsContext(DbContextOptions<MyBlogsContext> options) : base(options)
        {
        }
        public virtual DbSet<Blog> Blogs { get; set; }
    }
}
