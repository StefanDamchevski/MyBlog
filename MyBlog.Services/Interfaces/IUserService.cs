using MyBlog.Data;
using MyBlog.Service.Dto;
using System.Collections.Generic;

namespace MyBlog.Service.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();
        void Delete(int id);
        User GetById(int id);
        SignUpInResponse UpdateUser(User user);
    }
}
