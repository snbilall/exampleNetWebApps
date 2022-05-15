using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiProj.Models
{
    public class Category : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Başlık boş geçilemez!")]
        [MinLength(5, ErrorMessage = "Başlık minimum 5 karakterli olmalı")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Açıklama boş geçilemez!")]
        public string Description { get; set; }
        public List<Todo> Todos { get; set; }
    }
}
