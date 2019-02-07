using Data;
using Data.Interface;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogService.Services
{
   public class BlogService : IBlog
    {

        private BlogContext _context;
            public BlogService(BlogContext context )
            {
            this._context = context;   
            }

        public void add(Blog blog)
        {
            _context.blogs.Add(blog);
            _context.SaveChanges();

        }

        public IEnumerable<Blog> getAll()
        {
            return _context.blogs.ToList();
        }

        public IEnumerable<Blog> getById(int id)
        {
            return _context.blogs.Where(blog =>blog.iD== id);
        }

        public void update(Blog blog)
        {
            throw new NotImplementedException();
        }
        public void delete(Blog blog)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Blog> getUser(string userid)
        {
            return _context.blogs.Where(blog => blog.user == userid.ToString());
        }
    }
}
