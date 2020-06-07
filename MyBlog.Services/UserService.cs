using MyBlog.Data;
using MyBlog.Repository;
using MyBlog.Repository.Interfaces;
using MyBlog.Service.Interfaces;
using System.Collections.Generic;

namespace MyBlog.Service
{
    public class UserService : IUserService
    {
        public IUserRepository UserRepository { get; set; }
        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }
        public List<User> GetAll()
        {
            return UserRepository.GetAll();
        }

        public void Delete(int id)
        {
            UserRepository.Delete(id);
        }

        public User GetById(int id)
        {
            return UserRepository.GetById(id);
        }

        public void UpdateUser(User user)
        {
            UserRepository.Update(user);
        }
    }
}
