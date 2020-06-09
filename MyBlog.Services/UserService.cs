using MyBlog.Data;
using MyBlog.Repository.Interfaces;
using MyBlog.Service.Dto;
using MyBlog.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

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

        public SignUpInResponse UpdateUser(User updatedUser)
        {
            var users = UserRepository.GetAll()
                        .Where(x => x.Id != updatedUser.Id && x.Username != updatedUser.Username)
                        .ToList();

            var response = new SignUpInResponse();

            var user = UserRepository.GetById(updatedUser.Id);

            if (!users.Any())
            {
                user.Username = updatedUser.Username;
                user.Password = BCrypt.Net.BCrypt.HashPassword(updatedUser.Password);

                UserRepository.Update(user);
                response.IsSuccessful = true;
                return response;
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = $"Username {updatedUser.Username} already exists";
                return response;
            }

            
        }
    }
}
