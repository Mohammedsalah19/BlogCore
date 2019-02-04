using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Models;
using BlogService.Services;
using Data.Models;
using Data.Interface;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private IRegister _RegisterService;
        private Data.BlogContext _context;


        public HomeController(IRegister service)
        {
            this._RegisterService = service;
        }
        public IActionResult login(Register user)
        {

            _RegisterService.login(user);
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Register user  )
        {
             
            if (ModelState.IsValid)
            {
                _RegisterService.register(user);
                return RedirectToAction("Index", "Home");

            }

            return View(user);
        }


        public IActionResult Index()
        {
            _context.register.ToList();

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
