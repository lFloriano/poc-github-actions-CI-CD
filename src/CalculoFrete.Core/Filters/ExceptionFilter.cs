using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CalculoFrete.Core.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case InvalidOperationException:
                case ArgumentOutOfRangeException:
                case ArgumentNullException:
                    context.Result = new BadRequestObjectResult(new { message = context.Exception.Message });
                    break;

                case UnauthorizedAccessException ex:
                    context.Result = new UnauthorizedResult();
                    break;

                default:
                    context.Result = new StatusCodeResult(500);
                    break;
            }

            context.ExceptionHandled = true;
        }
    }
}
