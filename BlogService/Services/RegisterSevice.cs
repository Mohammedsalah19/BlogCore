using Data;
using Data.Interface;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BlogService.Services
{
   public class RegisterSevice : IRegister
    {
        private BlogContext _context;

        public RegisterSevice(BlogContext context)
        {
            this._context = context;
        }

        public IEnumerable<Register> GetAll()
        {
            return _context.register.ToList();
                
                }

        public Register login(Register model)
        {
            var obj = _context.register.Where(a => a.Email.Equals(model.Email) && a.Password.Equals(model.Password)).FirstOrDefault();
            if (obj == null)
            {
                return null;
            }
            else
                return obj;
        }

        public void register(Register user)
        {
            _context.register.Add(user);
            _context.SaveChanges();
         }
    }
}
