using DAL.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DAL.Serializers
{
    public class ShopJsonSerializer : BaseSerializer
    { 
        #region Constructors

        public ShopJsonSerializer(string serializationFolder)
            :base(serializationFolder)
        { }

        #endregion

        #region Methods

        public override IEnumerable<T> Load<T>()
        {
            IEnumerable<T> result = new List<T>();

            var fileName = GetFileName<T>("json");

            if (!File.Exists(fileName))
                return result;

            using (StreamReader file = File.OpenText(fileName))
            {
                var json = file.ReadToEnd();
                result = JsonConvert.DeserializeObject<List<T>>(json);
            }

            return result;
        }

        public override void Save<T>(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            if (!entities.Any())
                return;

            var serializer = new JsonSerializer();

            using (var streamWriter = new StreamWriter(GetFileName<T>("json")))
            using (var writer = new JsonTextWriter(streamWriter))
            {
                serializer.Serialize(writer, entities);
            }
        }

        #endregion
    }
}
