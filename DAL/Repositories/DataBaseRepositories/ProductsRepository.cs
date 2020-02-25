using DAL.DataEntities;
using DAL.Abstract;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public class ProductsRepository : GenericDataBaseRepository<Product>, IProductsRepository
    {
        public ProductsRepository(IShopDbContext context)
            : base(context)
        { }
    }
}
