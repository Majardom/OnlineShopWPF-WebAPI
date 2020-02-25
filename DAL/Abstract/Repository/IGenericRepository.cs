using System.Collections.Generic;
using DAL.DataEntities.Abstract;

namespace DAL.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : BaseDataEntity
    {
        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);

        void Remove(TEntity entity);

        void Update(TEntity entity);

        void SaveChanges();
    }
}
