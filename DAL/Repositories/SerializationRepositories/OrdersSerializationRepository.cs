using DAL.Abstract;
using DAL.DataEntities;

namespace DAL.Repositories
{
    public class OrdersSerializationRepository : GenericSerializationRepository<Order>, IOrdersRepository
    {
        public OrdersSerializationRepository(ISerializer serializer)
            :base(serializer)
        { }
    }
}
