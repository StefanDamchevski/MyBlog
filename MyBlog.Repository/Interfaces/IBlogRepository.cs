﻿using MyBlog.Data;
using System.Collections.Generic;

namespace MyBlog.Repository.Interfaces
{
    public interface IBlogRepository
    {
        List<Blog> GetAll();
        Blog GetById(int id);
        void Add(Blog blog);
        List<Blog> GetByTitle(string title);
        void Update(Blog blog);
        void Delete(int id);
    }
}
