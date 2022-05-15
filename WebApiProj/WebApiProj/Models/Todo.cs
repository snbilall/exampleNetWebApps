using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiProj.Models
{
    public class Todo : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Başlık boş geçilemez!")]
        [MinLength(5, ErrorMessage = "Başlık minimum 5 karakterli olmalı")]
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public bool isDone { get; set; }
        public Category Category { get; set; }
        public List<UserTodo> UserTodos { get; set; }
    }
}
