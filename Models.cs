using System;
using System.Collections.Generic;

namespace Models
{
    
    public class Movie
    {
        public int id { get; set;} 
        public String title { get; set; }
        public String genres { get; set; }
    }

    public class User
    {
        public int id { get; set; }
        public String name { get; set; }
        public String occupation { get; set; }
    }
}