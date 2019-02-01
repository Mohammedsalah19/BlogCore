using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data  
{
  public  class BlogContext:DbContext
    {
        public BlogContext(DbContextOptions options) : base(options)
        {

        }
      public DbSet<Register> register { get; set; }
        public DbSet<Blog> blogs { get; set; }
    }
}