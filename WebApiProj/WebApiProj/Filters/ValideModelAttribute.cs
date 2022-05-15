using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApiProj.Models;
using WebApiProj.Response;

namespace WebApiProj.Filters
{
    public class ValideModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                Response<BaseEntity> response = new Response<BaseEntity>();
                response.AddError("Hatalı veya eksik parametre");
                context.Result = new BadRequestObjectResult(response);
            }
        }
    }
}
