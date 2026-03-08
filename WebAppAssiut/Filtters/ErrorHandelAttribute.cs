using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAppAssiut.Filtters
{
    public class ErrorHandelAttribute : Attribute,IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //ContentResult resut= new ContentResult();
            //resut.Content = context.Exception.Message;
            ViewResult result=new ViewResult();
            result.ViewName = "Error";
            context.Result = result;
        }
    }
}
