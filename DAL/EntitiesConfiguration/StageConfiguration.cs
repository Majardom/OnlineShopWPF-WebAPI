using System.Data.Entity.ModelConfiguration;
using DAL.DataEntities;

namespace DAL.EntitiesConfiguration
{
    internal class StageConfiguration :EntityTypeConfiguration<Stage>
    {
        internal StageConfiguration()
        {
            HasKey<int>(x => x.Id);
            Property(x => x.Caption).HasMaxLength(50).IsRequired();
        }
    }
}
