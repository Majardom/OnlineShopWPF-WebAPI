using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL.Interfaces.Services;

namespace WebApi.Controllers
{
    /// <summary>
    /// Web Api controller to work with orders.
    /// </summary>
    [RoutePrefix("api/orders")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class OrdersController : ApiController
    {
        /// <summary>
        /// Orders service.
        /// </summary>
        private IOrdersService _service;

        /// <summary>
        /// Creates instance of orders web API controller. 
        /// </summary>
        /// <param name="service">Instance of order service.</param>
        public OrdersController(IOrdersService service)
        {
            _service = service;
        }

        /// <summary>
        /// Method to get all stored orders.
        /// </summary>
        /// <returns>List of orders.</returns>
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAllOrders()
        {
            var result = _service.GetAllOrders();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Method to get all stored order stages.
        /// </summary>
        /// <returns>List of orders stages.</returns>
        [HttpGet]
        [Route("stages")]
        public HttpResponseMessage GetAllOrderStages()
        {
            var result = _service.GetAllOrderStages();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Method to get order stage by id.
        /// </summary>
        /// <param name="id">Stage id.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("stages/{id:int}")]
        public HttpResponseMessage GetStageById(int id)
        {
            var result = _service.GetStageById(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Method to release unmanaged resources. 
        /// </summary>
        /// <param name="disposing">Describes weather method is called from finalizer or manually.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _service?.Dispose();
                _service = null;
            }

            base.Dispose(disposing);
        }
    }
}
