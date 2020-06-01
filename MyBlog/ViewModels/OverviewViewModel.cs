﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.ViewModels
{
    public class OverviewViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int DaysCreated { get; set; }
        public int Views { get; set; }
    }
}
