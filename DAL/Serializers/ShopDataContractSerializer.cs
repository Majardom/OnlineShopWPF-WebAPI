using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;

namespace DAL.Serializers
{
    public class ShopDataContractSerializer : BaseSerializer
    {
        #region Constructors

        public ShopDataContractSerializer(string serializationFolder)
            : base(serializationFolder)
        { }

        #endregion

        #region Methods

        public override IEnumerable<T> Load<T>()
        {
            IEnumerable<T> result = new List<T>();

            var fileName = GetFileName<T>("xml");

            if (!File.Exists(fileName))
                return result;

            var serializer = new DataContractSerializer(typeof(List<T>));
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                result = (List<T>)serializer.ReadObject(fs);
            }

            return result;
        }

        public override void Save<T>(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            if (!entities.Any())
                return;

            var serializer = new DataContractSerializer(typeof(List<T>));

            using (var fs = new FileStream(GetFileName<T>("xml"), FileMode.OpenOrCreate))
            {
                serializer.WriteObject(fs, entities.ToList());
            }
        }

        public override string GetFileName<T>(string fileExtention)
        {
            return $"{SerializationFolderPath}/DataContract{typeof(T).Name}s.{fileExtention}";
        }

        #endregion
    }
}
