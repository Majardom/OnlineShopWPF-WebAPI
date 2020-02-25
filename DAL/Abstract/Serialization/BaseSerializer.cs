using DAL.DataEntities.Abstract;
using System;
using System.Collections.Generic;

namespace DAL.Abstract
{
    public abstract class BaseSerializer : ISerializer
    {
        #region Fields

        protected string SerializationFolderPath;

        #endregion

        #region Constructors

        public BaseSerializer(string serializationFolderPath)
        {
            if (string.IsNullOrEmpty(serializationFolderPath))
                throw new ArgumentNullException(nameof(serializationFolderPath));

            SerializationFolderPath = serializationFolderPath;
        }

        #endregion

        #region Methods

        public abstract IEnumerable<TEntity> Load<TEntity>();

        public abstract void Save<TEntity>(IEnumerable<TEntity> entities);

        public virtual string GetFileName<TEntity>(string extention)
        {
            return $"{SerializationFolderPath}/{typeof(TEntity).Name}s.{extention}";
        }

        #endregion
    }
}
