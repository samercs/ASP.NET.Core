using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DBContext;
using WebApplication1.Entities;
using WebApplication1.Models.Blog;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class BlogController : Controller
    {

        private readonly MyDbContext _context;

        public BlogController(MyDbContext context)
        {
            _context = context;
        }
        
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var model = new BlogIndexViewModel()
            {
                Blogs = await _context.Blogs.Include(i => i.Posts).ToListAsync()
            };
            return View(model);
        }

        public IActionResult Add()
        {
            var model = new BlogAddViewModel()
            {
                Blog = new Blog()
            };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async  Task<IActionResult> Add(BlogAddViewModel model)
        {
            /*if(!ModelState.)
            {
                return RedirectToAction("Add");
            }*/
            var blog = new Blog()
            {
                Url = model.Blog.Url
            };
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
