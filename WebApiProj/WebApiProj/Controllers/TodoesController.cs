using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProj.Core.UOW;
using WebApiProj.DbContexts;
using WebApiProj.Filters;
using WebApiProj.Models;
using WebApiProj.Response;

namespace WebApiProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoesController : ControllerBase
    {
        private IUnitOfWork Worker;

        public TodoesController(IUnitOfWork Worker)
        {
            this.Worker = Worker;
        }

        // GET: api/Todoes
        [HttpGet]
        public ActionResult GetTodos()
        {
            var response = Worker.Todoes.GetAll();
            return Ok(new Response<Todo>(response));
        }

        // GET: api/Todoes/5
        [HttpGet("{id}")]
        public ActionResult GetTodo(int id)
        {
            var todo = Worker.Todoes.Get(id);

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(new Response<Todo>(todo));
        }

        // PUT: api/Todoes/5
        [HttpPut("{id}")]
        [CustomExceptionFilter]
        public ActionResult PutTodo(int id, Todo todo)
        {
            var item = Worker.Todoes.Get(id);
            if (item == null)
            {
                return NotFound(new Response<Todo>(new List<string> { "belirtilen id'li kayıt bulunamadı: " + id.ToString() }));
            }
            item.Name = todo.Name;
            item.Description = todo.Description;
            item.isDone = todo.isDone;
            Worker.Todoes.Update(item);
            Worker.Complete();
            return Ok(new Response<Todo>(item));
        }

        // POST: api/Todoes
        [HttpPost]
        [ValideModel]
        [CustomExceptionFilter]
        public ActionResult PostTodo(Todo todo)
        {
            Worker.Todoes.Add(todo);
            Worker.Complete();
            return Ok(new Response<Todo>(todo));
        }

        // DELETE: api/Todoes/5
        [HttpDelete("{id}")]
        public ActionResult DeleteTodo(int id)
        {
            var item = Worker.Todoes.Get(id);
            if (item == null)
            {
                return NotFound(new Response<Todo>(new List<string> { "belirtilen id'li kayıt bulunamadı: " + id.ToString() }));
            }
            Worker.Todoes.Remove(item);
            Worker.Complete();
            return Ok(new Response<Todo>(item));
        }
    }
}
