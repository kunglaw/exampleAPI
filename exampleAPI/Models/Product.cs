using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace exampleAPI.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set;  }
        public int stock { get; set;  }

    }
}