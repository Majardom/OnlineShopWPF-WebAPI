using System.Data.Entity.ModelConfiguration;
using DAL.DataEntities;

namespace DAL.EntitiesConfiguration
{
    internal class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        internal ProductConfiguration()
        {
            HasKey<int>(x => x.Id);
            Property(x => x.Caption).HasMaxLength(30).IsRequired();
            Property(x => x.Price).IsRequired();
            HasRequired(x => x.Category);
        }
    }
}
