using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApiProj.Core.Abstract;
using WebApiProj.Core.UOW;
using WebApiProj.Filters;
using WebApiProj.Models;
using WebApiProj.Response;

namespace WebApiProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CategoryController : ControllerBase
    {
        private IUnitOfWork Worker;

        public CategoryController(IUnitOfWork Worker)
        {
            this.Worker = Worker;
        }

        // GET: api/Category
        [HttpGet]
        //[Authorize(Roles = "Manager")]
        public IActionResult Get()
        {
            var response = Worker.Categories.GetAll();
            return Ok(new Response<Category>(response));
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "Get")]
        [CustomExceptionFilter]
        public IActionResult Get(int id)
        {
            var item = Worker.Categories.Get(id);
            return Ok(new Response<Category>(item));
        }
        
        // POST: api/Category
        [HttpPost]
        [ValideModel]
        [CustomExceptionFilter]
        public IActionResult Post([FromBody] Category category)
        {
            Worker.Categories.Add(category);
            Worker.Complete();
            return Ok(new Response<Category>(category));
        }
        
        // PUT: api/Category/5
        [HttpPut("{id}")]
        [ValideModel]
        [CustomExceptionFilter]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            var item = Worker.Categories.Get(id);
            if (item == null)
            {
                return NotFound(new Response<Category>(new List<string> { "belirtilen id'li kayıt bulunamadı: " + id.ToString() }));
            }
            item.Title = category.Title;
            item.Description = category.Description;
            Worker.Categories.Update(item);
            Worker.Complete();
            return Ok(new Response<Category>(item));
        }
        /*
        [HttpGet("{id}/todos")]
        public IActionResult Todos(int id)
        {
            // List<Todo> todos = context.Todos.Where(t => t.CategoryId == id).ToList();
            var items = from todos in context.Todos where todos.CategoryId == id select todos;
            List<Todo> todosList = items.ToList<Todo>();
            return Ok(new Response<Todo>(todosList));
        }*/

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [CustomExceptionFilter]
        public IActionResult Delete(int id)
        {
            var item = Worker.Categories.Get(id);
            if (item == null)
            {
                return NotFound(new Response<Category>(new List<string>{ "belirtilen id'li kayıt bulunamadı: " + id.ToString() }));
            }
            Worker.Categories.Remove(item);
            Worker.Complete();
            return Ok(new Response<Category>(item));
        }
    }
}
