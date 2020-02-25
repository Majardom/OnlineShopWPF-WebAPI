using DAL.DataEntities;
using DAL.Abstract;

namespace DAL.Repositories
{
    public class StagesRepository : GenericDataBaseRepository<Stage>, IStagesRepository
    {
        public StagesRepository(IShopDbContext context)
            :base(context)
        { }
    }
}
