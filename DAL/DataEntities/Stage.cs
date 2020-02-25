using DAL.DataEntities.Abstract;
using System;
using System.Runtime.Serialization;

namespace DAL.DataEntities
{
    [Serializable]
    [DataContract]
    public class Stage : BaseDataEntity
    {
        [DataMember]
        public string Caption { get; set; }
    }
}
