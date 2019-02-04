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

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(8, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
         [DataType(DataType.Password)]

        public string Password { get; set; }
         public DateTime BirthDate { get; set; }

        public string Photo { get; set; }
    }
}
