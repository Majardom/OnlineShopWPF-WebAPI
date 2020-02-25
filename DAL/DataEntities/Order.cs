using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DAL.DataEntities.Abstract;

namespace DAL.DataEntities
{
    [Serializable]
    [DataContract]
    public class Order : BaseDataEntity
    {
        [DataMember]
        public DateTime DateOfCreation { get; set; }

        [DataMember]
        public virtual Stage Stage { get; set; }

        [DataMember]
        public List<Product> Products { get; set; }

        [DataMember]
        public Person Person { get; set; }
    }
}
