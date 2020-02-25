using System.Runtime.Serialization;

namespace DAL.DataEntities.Abstract
{
    [DataContract]
    public abstract class BaseDataEntity
    {
        [DataMember]
        public int Id { get; set; }
    }
}
