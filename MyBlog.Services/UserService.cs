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
        private IUserRepository UserRepository { get; set; }
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

        public Response UpdateUser(int id, string username)
        {
            List<User> users = UserRepository.GetAll()
                        .Where(x => x.Id != id && x.Username == username)
                        .ToList();

            Response response = new Response();

            User user = UserRepository.GetById(id);

            if (!users.Any())
            {    
                user.Username = username;
                UserRepository.Update(user);
                response.IsSuccessful = true;
                return response;
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = $"Username {username} already exists";
                return response;
            }
        }

        public Response Create(string username, string password)
        {
            User user = UserRepository.GetByUsername(username);
            Response response = new Response();
            if(user == null)
            {
                User newUser = new User()
                {
                    Username = username,
                    Password = BCrypt.Net.BCrypt.HashPassword(password),
                    IsAdmin = false,
                };

                UserRepository.Add(newUser);

                response.IsSuccessful = true;
                return response;
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = $"Username {username} already exists";
                return response;
            }
        }

        public void GiveAdminRole(int id)
        {
            User user = UserRepository.GetById(id);
            user.IsAdmin = true;
            UserRepository.Update(user);
        }

        public void RemoveAdminRole(int id)
        {
            User user = UserRepository.GetById(id);
            user.IsAdmin = false;
            UserRepository.Update(user);
        }

        public void ChangePassword(int id, string password)
        {
            User user = UserRepository.GetById(id);
            user.Password = BCrypt.Net.BCrypt.HashPassword(password);
            UserRepository.Update(user);
        }
    }
}
