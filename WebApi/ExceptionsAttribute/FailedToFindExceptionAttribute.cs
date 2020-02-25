using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using BLL.Exceptions;

namespace WebApi.ExceptionsAttribute
{
    internal class FailedToFindExceptionAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        ///  Filter which handles errors related to FailedToFindException which occurs on BLL layer.
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is FailedToFindException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }
    }
}