using System.Collections.Generic;

namespace DAL.Abstract
{
    public interface ISerializer
    {
        IEnumerable<TEntity> Load<TEntity>();

        void Save<TEntity>(IEnumerable<TEntity> entities);
    }
}
