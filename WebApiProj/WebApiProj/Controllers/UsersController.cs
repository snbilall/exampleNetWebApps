using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    public class UsersController : ControllerBase
    {
        IUnitOfWork Worker;
        public UsersController(IUnitOfWork Worker)
        {
            this.Worker = Worker;
        }

        [HttpGet("{id}")]
        [CustomExceptionFilter]
        public ActionResult Get(int id)
        {
            var user = Worker.Users.Get(id);
            return Ok(new Response<User>(user));
        }
        /*
        [HttpGet("{id}/todos")]
        [CustomExceptionFilter]
        public ActionResult Todoes(int id)
        {
            var user = context.Users.Include(u => u.UserTodos)
                .ThenInclude(userTodo => userTodo.Todo).FirstOrDefault(u => u.Id == id);
            return Ok(new Response<Object>(user));
        }*/
    }
}