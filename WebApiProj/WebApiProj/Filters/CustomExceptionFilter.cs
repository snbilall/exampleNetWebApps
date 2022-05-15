using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApiProj.Models;
using WebApiProj.Response;

namespace WebApiProj.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            Response<BaseEntity> response = new Response<BaseEntity>();
            response.AddError("Hata oluştu: " + context.Exception.Message);
            response.Entity = null;
            context.Result = new BadRequestObjectResult(response);
        }
    }
}
