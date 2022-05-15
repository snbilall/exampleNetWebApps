using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ExampleApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExampleApp.Controllers
{
    public class HelloController : Controller
    {/*
        private readonly BloggingContext _context;

        public HelloController(BloggingContext context)
        {
            _context = context;
        }
        // 
        // GET: /HelloWorld/

        public IActionResult Index()
        {
            // Create
            Console.WriteLine("Inserting a new blog");
            _context.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
            _context.SaveChanges();

            // Read
            Console.WriteLine("Querying for a blog");
            var blog = _context.Blogs
                .OrderBy(b => b.BlogId)
                .First();

            // Update
            Console.WriteLine("Updating the blog and adding a post");
            blog.Url = "https://devblogs.microsoft.com/dotnet";
            blog.Posts.Add(
                new Post
                {
                    Title = "Hello World",
                    Content = "I wrote an app using EF Core!"
                });
            _context.SaveChanges();

            // Delete
            Console.WriteLine("Delete the blog");
            _context.Remove(blog);
            _context.SaveChanges();
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }*/
    }
}
