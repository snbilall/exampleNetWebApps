using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProj.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Başlık boş geçilemez!")]
        public string Name { get; set; }
        public string IdentityNumber { get; set; }
        public string Job { get; set; }
        public List<Todo> Todos { get; set; }
        public List<UserTodo> UserTodos { get; set; }
    }
}
