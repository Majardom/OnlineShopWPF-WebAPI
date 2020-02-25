using DAL.Abstract;
using DAL.DataEntities;

namespace DAL.Repositories.SerializationRepositories
{
    public class StagesSerializationRepository : GenericSerializationRepository<Stage>, IStagesRepository
    {
        public StagesSerializationRepository(ISerializer serializer)
            : base(serializer)
        { }
    }
}
