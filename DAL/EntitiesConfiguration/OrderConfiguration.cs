using System.Data.Entity.ModelConfiguration;
using DAL.DataEntities;

namespace DAL.EntitiesConfiguration
{
    internal class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        internal OrderConfiguration()
        {
            HasKey<int>(x => x.Id);
            Property(x => x.DateOfCreation).HasColumnType("datetime2").IsRequired();
            HasMany(x => x.Products);
            HasRequired(x => x.Stage);
            HasRequired(x => x.Person);
        }
    }
}
