using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace fiapweb2022.api.ActionFilters
{
    public class CustomAuthorize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (
                 context.HttpContext.Request.Headers["x-api-key"].Count == 0
                 ||
                 context.HttpContext.Request.Headers["x-api-key"].FirstOrDefault() != "1F8Ts6ecx13"
                )
            {
                //descobrir a acao => RemoverAluno
                //Clain => Role => Professor
                //DB.Where(a=>a.==professor) == RemoverAluno
                //IsAllowed(RemoverAluno, professor)

                context.Result = new UnauthorizedResult();
            }
        }
    }
}
