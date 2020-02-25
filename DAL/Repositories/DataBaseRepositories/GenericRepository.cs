using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.DataEntities.Abstract;
using DAL.Abstract;
using System;

namespace DAL.Repositories
{
    public class GenericDataBaseRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseDataEntity
    {
        #region Fields

        protected DbSet<TEntity> Entities;
        protected IShopDbContext Context;

        #endregion

        #region Contructors

        public GenericDataBaseRepository(IShopDbContext context)
        {
            Context = context
                ?? throw new ArgumentNullException(nameof(context));

            Entities = context.Set<TEntity>();

            Entities.Load();
        }

        #endregion

        #region Methods

        public TEntity GetById(int id)
        {
            if (id < 0)
                throw new ArgumentException(nameof(id));

            return Entities.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Entities;
        }

        public void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Entities.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Entities.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var currentEntity = GetById(entity.Id);
            Context.Entry(currentEntity).CurrentValues.SetValues(entity);
            Context.Entry(currentEntity).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        #endregion
    }
}
