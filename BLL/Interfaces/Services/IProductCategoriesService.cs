using System;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces.Services
{
    public interface IProductCategoriesService : IDisposable
    {
        IEnumerable<ProductCategoryDto> GetAllProductCategories();
    }
}
