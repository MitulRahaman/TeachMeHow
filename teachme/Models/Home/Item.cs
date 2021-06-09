using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using teachme.DAL;

namespace teachme.Models.Home
{
    public class Item
    {
        public Course Courses { get; set; }
        public int Quantity { get; set; }
    }
}