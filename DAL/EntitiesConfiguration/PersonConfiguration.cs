using DAL.DataEntities;
using System.Data.Entity.ModelConfiguration;

namespace DAL.EntitiesConfiguration
{
    internal class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        internal PersonConfiguration()
        {
            HasKey<int>(x => x.Id);
            Property(x => x.DateOfBirth).HasColumnType("datetime2").IsRequired();
            Property(x => x.Address).IsRequired();
            Property(x => x.Name).IsRequired();
            Property(x => x.PhoneNumber).IsRequired();
        }
    }
}
