using BLL.Interfaces.Services;
using BLL.Services;
using Ninject.Modules;
using Ninject.Web.Common;

namespace WebApi.DependencyConfiguration
{
    /// <summary>
    /// Ninject module for dependencies settings.
    /// </summary>
    public class BllModule : NinjectModule
    {
        /// <summary>
        /// Method to set bindings for Bll services.
        /// </summary>
        public override void Load()
        {
            Bind<IOrdersService>().To<OrdersService>().InRequestScope();
            Bind<IProductCategoriesService>().To<ProductCategoriesService>().InRequestScope();
            Bind<IProductsService>().To<ProductsService>().InRequestScope();
        }
    }
}