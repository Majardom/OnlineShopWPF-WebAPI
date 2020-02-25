using DAL.DataEntities;
using DAL.Abstract;


namespace DAL.Repositories
{
    public class OrdersRepository : GenericDataBaseRepository<Order>, IOrdersRepository
    {
        public OrdersRepository(IShopDbContext context)
            :base(context)
        {}
    }
}
