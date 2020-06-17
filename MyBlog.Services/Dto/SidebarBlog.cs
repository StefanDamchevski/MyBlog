﻿using System;

namespace MyBlog.Service.Dto
{
    public class SidebarBlog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? DateCreated { get; set; }
        public int Views { get; set; }
        public bool IsApproved { get; set; }
    }
}
