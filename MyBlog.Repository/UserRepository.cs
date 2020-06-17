using MyBlog.Data;
using MyBlog.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

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

        public void Add(User newUser)
        {
            Context.Users.Add(newUser);
            Context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return Context.Users.ToList();
        }

        public void Delete(int id)
        {
            User user = new User()
            {
                Id = id,
            };

            Context.Users.Remove(user);
            Context.SaveChanges();
        }

        public User GetById(int id)
        {
            return Context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Update(User user)
        {
            Context.Users.Update(user);
            Context.SaveChanges();
        }
    }
}
