using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.DTO;
using BLL.Exceptions;
using BLL.Interfaces.Services;
using BLL.Services.Abstract;
using DAL.Abstract;
using DAL.DataEntities;
using Ninject;

namespace BLL.Services
{
    /// <summary>
    /// Class representing service to work with products 
    /// </summary>
    public class ProductsService : BaseService, IProductsService
    {

        /// <summary>
        /// Creates instance of products service.
        /// </summary>
        /// <param name="dbUnitOfWork"></param>
        public ProductsService([Named("DB")]IUnitOfWork dbUnitOfWork, 
            [Named("Json")]IUnitOfWork serJsonUnitOfWork, 
            [Named("Xml")]IUnitOfWork serXmlUnitOfWork, 
            [Named("DataContract")]IUnitOfWork serDataContractUnitOfWork)
            : base(dbUnitOfWork, serJsonUnitOfWork, serXmlUnitOfWork, serDataContractUnitOfWork)
        { }

        /// <summary>
        /// Method to get all stored products.
        /// </summary>
        /// <returns>List of products.</returns>
        public IEnumerable<ProductDto> GetAllProducts()
        {
            var resultFromDb = DbUnitOfWork.Products.GetAll().ToList();

            if (!resultFromDb.Any())
                throw new FailedToFindException("Orders not found");

            return Mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(resultFromDb);
        }

        /// <summary>
        /// Method to get product by id.
        /// </summary>
        /// <param name="id">Product id.</param>
        /// <returns>Founded product.</returns>
        public ProductDto GetProductById(int id)
        {
            var resultFromDb = DbUnitOfWork.Products.GetById(id);

            if (resultFromDb == null)
                throw new FailedToFindException("Orders not found");

            return Mapper.Map<Product, ProductDto>(resultFromDb);
        }

        public void SaveToJson(List<ProductDto> products)
        {
            products.ForEach(x => SerJsonUnitOfWork.Products.Add(Mapper.Map<ProductDto, Product>(x)));

            SerJsonUnitOfWork.Save();
        }

        public void SaveToXml(List<ProductDto> products)
        {
            products.ForEach(x => SerXmlUnitOfWork.Products.Add(Mapper.Map<ProductDto, Product>(x)));

            SerXmlUnitOfWork.Save();
        }

        public void SaveToDataContract(List<ProductDto> products)
        {
            products.ForEach(x => SerDataContractUnitOfWork.Products.Add(Mapper.Map<ProductDto, Product>(x)));

            SerDataContractUnitOfWork.Save();
        }
    }
}
