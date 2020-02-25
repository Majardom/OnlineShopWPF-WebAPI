using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApi.ExceptionsAttribute
{
    internal class ValidateModelAttribute : ActionFilterAttribute
    {
        /// <summary>
        ///  Filter which handles errors related to model state validation.
        /// </summary>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ModelState.IsValid == false)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, actionContext.ModelState);
            }
        }
    }
}