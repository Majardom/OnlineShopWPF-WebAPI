using DAL.Abstract;
using DAL.DataEntities;

namespace DAL.Repositories
{
    public class ProductCategoriesSerializationRepository : GenericSerializationRepository<ProductCategory>, IProductsCategoriesRepository
    {
        public ProductCategoriesSerializationRepository(ISerializer serializer)
            : base(serializer)
        { }
    }
}
