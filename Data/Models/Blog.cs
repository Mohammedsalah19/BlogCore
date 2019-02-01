using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
  public  class Blog
    {
        public int iD { get; set; }
        public string Tiltle { get; set; }
        public string body { get; set; }
        public string user { get; set; }
        public DateTime Datetime { get; set; }
        public string Subject { get; set; }

        public string rate { get; set; }
    }
}
