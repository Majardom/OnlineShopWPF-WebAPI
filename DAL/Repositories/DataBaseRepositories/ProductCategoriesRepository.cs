using DAL.DataEntities;
using DAL.Abstract;

namespace DAL.Repositories
{
    public class ProductCategoriesRepository : GenericDataBaseRepository<ProductCategory>, IProductsCategoriesRepository
    {
        public ProductCategoriesRepository(IShopDbContext context)
            : base(context)
        { }
    }
}
