using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProj.Models
{
    public class UserTodo
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int TodoId { get; set; }
        public Todo Todo { get; set; }
    }
}
