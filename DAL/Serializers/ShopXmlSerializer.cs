using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using DAL.Abstract;

namespace DAL.Serializers
{
    public class ShopXmlSerializer : BaseSerializer
    {
        #region Constructors

        public ShopXmlSerializer(string serializationFolder)
            :base(serializationFolder)
        { }

        #endregion

        #region Methods

        public override IEnumerable<T> Load<T>()
        {
            IEnumerable <T> result = new List<T>();

            if (!File.Exists(GetFileName<T>("xml")))
                return result;

            var serializer = new XmlSerializer(typeof(List<T>));
            using (var fs = new FileStream(GetFileName<T>("xml"), FileMode.OpenOrCreate))
            {
                result = (List<T>)serializer.Deserialize(fs);
            }

            return result;
        }

        public override void Save<T>(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            if (!entities.Any())
                return;

            var serializer = new XmlSerializer(typeof(List<T>));

            using (var fs = new FileStream(GetFileName<T>("xml"), FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, entities.ToList());
            }
        }

        #endregion
    }
}
