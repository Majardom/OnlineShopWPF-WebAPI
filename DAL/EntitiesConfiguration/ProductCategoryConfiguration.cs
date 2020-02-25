using System.Data.Entity.ModelConfiguration;
using DAL.DataEntities;

namespace DAL.EntitiesConfiguration
{
    internal class ProductCategoryConfiguration : EntityTypeConfiguration<ProductCategory>
    {
        internal ProductCategoryConfiguration()
        {
            HasKey<int>(category => category.Id);
            Property(category => category.Caption).IsRequired();
            Property(category => category.Description);
        }
    }
}
