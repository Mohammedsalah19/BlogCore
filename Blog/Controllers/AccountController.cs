using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Interface;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    public class AccountController : Controller
    {
        private IRegister _RegisterService;
        private BlogContext _context;

        public AccountController(IRegister service, BlogContext context)
        {
            this._RegisterService = service;
            this._context = context;
        }
        public  IActionResult Index()
        {

             return View(_RegisterService.GetAll());
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Register user)
        {

            if (ModelState.IsValid)
            {
                user.Password = BCrypt.Net.BCrypt.HashString(user.Password);
            _RegisterService.register(user);

            return RedirectToAction(nameof(Index));


            }
            return View();



        }

        public IActionResult Login(Register user)
        {
           
            var acc = CheckPass(user.Email, user.Password);
            if (acc != null)
            {
                var obj = _RegisterService.login(acc);

                if (obj != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();

        }


        private Register CheckPass(string email , string pass)
        {


            var user = _context.register.SingleOrDefault(s => s.Email == email);
            if (user !=null)

            {
                if (BCrypt.Net.BCrypt.Verify(pass, user.Password)) 
                {
                    return user;
                }
            }

            return null;
           
            
        }



    }
}