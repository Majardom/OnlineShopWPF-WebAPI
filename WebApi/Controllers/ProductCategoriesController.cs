using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL.Interfaces.Services;

namespace WebApi.Controllers
{
    /// <summary>
    ///  Web Api controller to work with orders.
    /// </summary>
    [RoutePrefix("api/categories")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ProductCategoriesController : ApiController
    {
        /// <summary>
        /// Product categories service.
        /// </summary>
        private IProductCategoriesService _service;

        /// <summary>
        /// Creates instance of product categories web API controller.
        /// </summary>
        /// <param name="service">Instance of product categories service.</param>
        public ProductCategoriesController(IProductCategoriesService service)
        {
            _service = service;
        }

        /// <summary>
        /// Method to get all stored product categories.
        /// </summary>
        /// <returns>List of product categories.</returns>
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAllProductCategories()
        {
            var result = _service.GetAllProductCategories();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        ///    Method to get category description by id.
        /// </summary>
        /// <param name="id">Category id.</param>
        /// <returns>Category description object.</returns>
        [HttpGet]
        [Route("{id:int}/description")]
        public HttpResponseMessage GetCategoryDescriptionByProductCategoryId(int id)
        {
            var result = _service.GetCategoryDescriptionDtoByProductCategoryId(id);
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
