using DAL.DataEntities.Abstract;
using System;
using System.Runtime.Serialization;

namespace DAL.DataEntities
{
    [Serializable]
    [DataContract]
    public class Product : BaseDataEntity
    {
        [DataMember]
        public string Caption { get; set; }

        [DataMember]
        public virtual ProductCategory Category { get; set; }

        [DataMember]
        public double Price { get; set; }
    }
}
