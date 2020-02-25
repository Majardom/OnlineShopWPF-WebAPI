using DAL.Abstract;
using DAL.Repositories;
using DAL.Repositories.SerializationRepositories;
using DAL.Serializers;
using DAL.ShopDbContext;
using DAL.UnitOfWork;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using System.Linq;

namespace BLL.DependencyConfiguration
{
    /// <summary>
    /// Ninject module for dependencies settings.
    /// </summary>
    public class DalModule : NinjectModule
    {
        /// <summary>
        /// Connection string to data base.
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Creates instance of ninject module.
        /// </summary>
        /// <param name="connectionString"></param>
        public DalModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Method to set bindings for DAL classes.
        /// </summary>
        public override void Load()
        {
            Bind<IShopDbContext>().To<ShopDbContext>().InRequestScope().WithConstructorArgument(_connectionString);
            

            Bind<IProductsRepository>().To<ProductsRepository>().InRequestScope().Named("DB");
            Bind<IOrdersRepository>().To<OrdersRepository>().InRequestScope().Named("DB");
            Bind<IProductsCategoriesRepository>().To<ProductCategoriesRepository>().InRequestScope().Named("DB");
            Bind<IStagesRepository>().To<StagesRepository>().InRequestScope().Named("DB");

            var orderRepo = Kernel.Get<IOrdersRepository>("DB");
            var productRepo = Kernel.Get<IProductsRepository>("DB");
            var categoriesRepo = Kernel.Get<IProductsCategoriesRepository>("DB");
            var stagesRepo = Kernel.Get<IStagesRepository>("DB");

            Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope().Named("DB")
              .WithConstructorArgument("orders", orderRepo)
              .WithConstructorArgument("categories", categoriesRepo)
              .WithConstructorArgument("products", productRepo)
              .WithConstructorArgument("stages", stagesRepo);

            var folder = @"D:\TESTSERIALIZATION";

            Bind<ISerializer>().To<ShopDataContractSerializer>().InSingletonScope().Named("DataContract").WithConstructorArgument("serializationFolder", folder);
            Bind<ISerializer>().To<ShopXmlSerializer>().InSingletonScope().Named("Xml").WithConstructorArgument("serializationFolder", folder);
            Bind<ISerializer>().To<ShopJsonSerializer>().InSingletonScope().Named("Json").WithConstructorArgument("serializationFolder", folder);

            var serializer = Kernel.Get<ISerializer>("Json");

            Bind<IProductsRepository>().To<ProductSerializationRepository>().InRequestScope().Named("SerializeJson").WithConstructorArgument("serializer", serializer);
            Bind<IOrdersRepository>().To<OrdersSerializationRepository>().InRequestScope().Named("SerializeJson").WithConstructorArgument("serializer", serializer);
            Bind<IProductsCategoriesRepository>().To<ProductCategoriesSerializationRepository>().InRequestScope().Named("SerializeJson").WithConstructorArgument("serializer", serializer);
            Bind<IStagesRepository>().To<StagesSerializationRepository>().InRequestScope().Named("SerializeJson").WithConstructorArgument("serializer", serializer);

            orderRepo = Kernel.Get<IOrdersRepository>("SerializeJson");
            productRepo = Kernel.Get<IProductsRepository>("SerializeJson");
            categoriesRepo = Kernel.Get<IProductsCategoriesRepository>("SerializeJson");
            stagesRepo = Kernel.Get<IStagesRepository>("SerializeJson");

            Bind<IUnitOfWork>().To<UnitOfWorkSerialization>().InRequestScope()
                .Named("Json")
                .WithConstructorArgument("orders", orderRepo)
                .WithConstructorArgument("categories", categoriesRepo)
                .WithConstructorArgument("products", productRepo)
                .WithConstructorArgument("stages", stagesRepo)
                .WithConstructorArgument("serializer", serializer);

            serializer = Kernel.Get<ISerializer>("Xml");

            Bind<IProductsRepository>().To<ProductSerializationRepository>().InRequestScope().Named("SerializeXml").WithConstructorArgument("serializer", serializer);
            Bind<IOrdersRepository>().To<OrdersSerializationRepository>().InRequestScope().Named("SerializeXml").WithConstructorArgument("serializer", serializer);
            Bind<IProductsCategoriesRepository>().To<ProductCategoriesSerializationRepository>().InRequestScope().Named("SerializeXml").WithConstructorArgument("serializer", serializer);
            Bind<IStagesRepository>().To<StagesSerializationRepository>().InRequestScope().Named("SerializeXml").WithConstructorArgument("serializer", serializer);

            orderRepo = Kernel.Get<IOrdersRepository>("SerializeXml");
            productRepo = Kernel.Get<IProductsRepository>("SerializeXml");
            categoriesRepo = Kernel.Get<IProductsCategoriesRepository>("SerializeXml");
            stagesRepo = Kernel.Get<IStagesRepository>("SerializeXml");

            Bind<IUnitOfWork>().To<UnitOfWorkSerialization>().InRequestScope()
                .Named("Xml")
                .WithConstructorArgument("orders", orderRepo)
                .WithConstructorArgument("categories", categoriesRepo)
                .WithConstructorArgument("products", productRepo)
                .WithConstructorArgument("stages", stagesRepo)
                .WithConstructorArgument("serializer", serializer);

            serializer = Kernel.Get<ISerializer>("DataContract");

            Bind<IProductsRepository>().To<ProductSerializationRepository>().InRequestScope().Named("SerializeDataContract").WithConstructorArgument("serializer", serializer);
            Bind<IOrdersRepository>().To<OrdersSerializationRepository>().InRequestScope().Named("SerializeDataContract").WithConstructorArgument("serializer", serializer);
            Bind<IProductsCategoriesRepository>().To<ProductCategoriesSerializationRepository>().InRequestScope().Named("SerializeDataContract").WithConstructorArgument("serializer", serializer);
            Bind<IStagesRepository>().To<StagesSerializationRepository>().InRequestScope().Named("SerializeDataContract").WithConstructorArgument("serializer", serializer);

            orderRepo = Kernel.Get<IOrdersRepository>("SerializeDataContract");
            productRepo = Kernel.Get<IProductsRepository>("SerializeDataContract");
            categoriesRepo = Kernel.Get<IProductsCategoriesRepository>("SerializeDataContract");
            stagesRepo = Kernel.Get<IStagesRepository>("SerializeDataContract");

            Bind<IUnitOfWork>().To<UnitOfWorkSerialization>().InRequestScope()
                .Named("DataContract")
                .WithConstructorArgument("orders", orderRepo)
                .WithConstructorArgument("categories", categoriesRepo)
                .WithConstructorArgument("products", productRepo)
                .WithConstructorArgument("stages", stagesRepo)
                .WithConstructorArgument("serializer", serializer);
        }
    }
}
