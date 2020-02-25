using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL.Interfaces.Services;

namespace WebApi.Controllers
{
    /// <summary>
    /// Web Api controller to work with products.
    /// </summary>
    [RoutePrefix("api/products")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ProductsController : ApiController
    {
        /// <summary>
        ///  Products  service.
        /// </summary>
        private IProductsService _service;


        /// <summary>
        /// Creates instance of products web API controller.
        /// </summary>
        /// <param name="service">Instance of products service.</param>
        public ProductsController(IProductsService service)
        {
            _service = service;
        }

        /// <summary>
        /// Method to get all stored products.
        /// </summary>
        /// <returns>List of products.</returns>
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAllProducts()
        {
            var result = _service.GetAllProducts();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Method to get product by id.
        /// </summary>
        /// <param name="id">Product id.</param>
        /// <returns>Founded product.</returns>
        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetProductById(int id)
        {
            var result = _service.GetProductById(id);
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
