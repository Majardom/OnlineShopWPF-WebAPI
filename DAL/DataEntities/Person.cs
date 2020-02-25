using DAL.DataEntities.Abstract;
using System;
using System.Runtime.Serialization;

namespace DAL.DataEntities
{
    [Serializable]
    [DataContract]
    public class Person : BaseDataEntity
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DateTime DateOfBirth { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string Address { get; set; } 
    }
}
