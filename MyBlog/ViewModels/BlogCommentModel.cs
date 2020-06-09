using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.ViewModels
{
    public class BlogCommentModel
    {
        public string Comment { get; set; }
        public string Username { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
