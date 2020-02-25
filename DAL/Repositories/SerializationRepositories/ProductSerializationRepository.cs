using DAL.Abstract;
using DAL.DataEntities;

namespace DAL.Repositories.SerializationRepositories
{
    public class ProductSerializationRepository : GenericSerializationRepository<Product>, IProductsRepository
    {
        public ProductSerializationRepository(ISerializer serializer)
            : base(serializer)
        { }
    }
}
