using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.DTO;
using BLL.Exceptions;
using BLL.Interfaces.Services;
using BLL.Services.Abstract;
using DAL.Abstract;
using DAL.DataEntities;

namespace BLL.Services
{
    /// <summary>
    /// Class representing service to work with product categories.
    /// </summary>
    public class ProductCategoriesService : BaseService, IProductCategoriesService
    {
        /// <summary>
        /// Creates instance of product categories service.
        /// </summary>
        /// <param name="dbUnitOfWork"></param>
        public ProductCategoriesService(IUnitOfWork dbUnitOfWork) 
            : base(dbUnitOfWork)
        { }


        /// <summary>
        /// Method to get all stored product categories.
        /// </summary>
        /// <returns>List of product categories.</returns>
        public IEnumerable<ProductCategoryDto> GetAllProductCategories()
        {
            var resultFromDb = DbUnitOfWork.Categories.GetAll().ToList();

            if (!resultFromDb.Any())
                throw new FailedToFindException("Orders not found");

            return Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryDto>>(resultFromDb);
        }

        /// <summary>
        ///    Method to get category description by id.
        /// </summary>
        /// <param name="id">Category id.</param>
        /// <returns>Category description</returns>
        public string GetCategoryDescriptionDtoByProductCategoryId(int id)
        {
            var resultFromDb = DbUnitOfWork.Categories.GetById(id).Description;

            if (resultFromDb == null)
                throw new FailedToFindException("Orders not found");

            return resultFromDb;
        }
    }
}
