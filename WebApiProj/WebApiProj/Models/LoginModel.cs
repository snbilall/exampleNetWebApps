using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProj.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Parola boş geçilemez")]
        public string Password { get; set; }
    }
}
