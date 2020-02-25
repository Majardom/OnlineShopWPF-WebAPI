using System.Data.Entity;
using DAL.DataEntities;
using DAL.EntitiesConfiguration;
using DAL.Abstract;

namespace DAL.ShopDbContext
{
    public class ShopDbContext : DbContext, IShopDbContext
    {
        static ShopDbContext()
        {
           Database.SetInitializer(new ShopDbInitializer());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Stage> Stages { get; set; }

        public ShopDbContext(string connectionString)
            : base(connectionString)
        {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new ProductCategoryConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new StageConfiguration());
            modelBuilder.Configurations.Add(new PersonConfiguration());
        }
    }
}
