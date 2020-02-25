using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DAL.DataEntities;

namespace DAL.Abstract
{
    public interface IShopDbContext : IDisposable
    {
        DbSet<Product> Products { get; set; }
        DbSet<ProductCategory> ProductCategories { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Stage> Stages { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
    }
}
