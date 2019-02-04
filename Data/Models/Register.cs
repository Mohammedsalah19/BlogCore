using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
  public  class Register
    {
        public int id { get; set; }
        [Required]
        public string Fname { get; set; }
        public string Lname { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
         public DateTime BirthDate { get; set; }

        public string Photo { get; set; }
    }
}
