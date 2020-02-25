using System;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces.Services
{
    public interface IProductsService : IDisposable
    {
        IEnumerable<ProductDto> GetAllProducts();

        ProductDto GetProductById(int id);

        void SaveToJson(List<ProductDto> products);

        void SaveToXml(List<ProductDto> products);

        void SaveToDataContract(List<ProductDto> products);
    }
}
