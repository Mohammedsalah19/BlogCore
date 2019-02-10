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
using Data;
using Microsoft.AspNetCore.Http;
using PagedList.Core;
 namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private IBlog _blogService;
        private Data.BlogContext _context;


        public HomeController(IBlog service, BlogContext context)
        {
            this._blogService = service;
            this._context = context;
        }
 


        public IActionResult Index(int page=1 , int listSize= 3)
        {
            PagedList<Data.Models.Blog> model = new PagedList<Data.Models.Blog>(_context.blogs, page, listSize);
            //_blogService.getAll()
            return View(model);
        }


        public PartialViewResult Search(string SeacrhText)
        {
           
            var dd = _context.blogs.Where(s => s.Tiltle.StartsWith(SeacrhText));
            return PartialView("Search",dd);
        }

        public JsonResult autoSearch(string Prefix)
        {

            var ps = from p in _context.blogs
                     where p.Tiltle.StartsWith(Prefix)
                     select new { Name = p.Tiltle };

            return Json(ps.ToList().Take(5));
        }



        #region Create

        [HttpGet]
        public IActionResult create()
        {
                 if (HttpContext.Session.GetString("Name") !=null)
            {
                return View();

            }
            return RedirectToAction("login", "Account");
                
        }
        [HttpPost]
        public IActionResult create(Data.Models.Blog blog)
        {
                if (ModelState.IsValid)
                {
                blog.Datetime = DateTime.Now;
                blog.user = HttpContext.Session.GetString("Name");

                 _blogService.add(blog);
                    return RedirectToAction(nameof(Index));
                }
 
            return View();
        }

        #endregion

        #region BlogID
        public IActionResult Blog(int id)
        {
            
            return View(_blogService.getById(id));
        }

        #endregion
        #region Get user blogs
        public IActionResult User(string id)
        {

            return View(_blogService.getUser(id));
        }

        #endregion

        #region contact

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        #endregion

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
