using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interface
{
    public   interface IBlog
    {


        IEnumerable<Blog> getAll();
        IEnumerable<Blog> getById(int id);
        void add(Blog blog);
        void delete(Blog blog);
        void update(Blog blog);

        IEnumerable<Blog> getUser(int id);


    }
}
