using Microsoft.EntityFrameworkCore;
using MyBlog.Data;
using MyBlog.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MyBlog.Repository
{
    public class UserRepository : IUserRepository
    {
        public MyBlogsContext Context { get; set; }
        public UserRepository(MyBlogsContext context)
        {
            Context = context;
        }
        public User GetByUsername(string username)
        {
          return Context.Users.FirstOrDefault(x => x.Username == username);
        }
    }
}
