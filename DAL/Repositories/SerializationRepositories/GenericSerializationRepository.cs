using DAL.Abstract;
using DAL.DataEntities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class GenericSerializationRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseDataEntity
    {
        #region Fields 

        protected ISerializer Serializer;
        protected List<TEntity> Entities;

        #endregion

        #region Constructors

        public GenericSerializationRepository(ISerializer serializer)
        {
            serializer = serializer
                ?? throw new ArgumentNullException(nameof(serializer));

            Entities = serializer.Load<TEntity>().ToList();
        }

        #endregion

        #region Methods

        public void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Entities.Add(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Entities;
        }

        public TEntity GetById(int id)
        {
            if (id < 0)
                throw new ArgumentException(nameof(id));

            return Entities.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var entityToRemove = Entities.FirstOrDefault(x => x.Id == entity.Id);
            if (entityToRemove == null)
                throw new InvalidOperationException("Entity has not been stored on a disk; There is nothing to remove");

            Entities.Remove(entityToRemove);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var entityToUpdate = Entities.FirstOrDefault(x => x.Id == entity.Id);
            if (entityToUpdate == null)
                throw new InvalidOperationException("Unable to update entity does not exist");

            Entities.Remove(entityToUpdate);
            Entities.Add(entity);
        }

        public void SaveChanges()
        {
            Serializer.Save(Entities);
        }

        #endregion
    }
}
