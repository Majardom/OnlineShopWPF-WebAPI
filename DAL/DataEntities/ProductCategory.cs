
using DAL.DataEntities.Abstract;
using System;
using System.Runtime.Serialization;

namespace DAL.DataEntities
{
    [Serializable]
    [DataContract]
    public class ProductCategory : BaseDataEntity
    {
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Caption { get; set; }
    }
}
