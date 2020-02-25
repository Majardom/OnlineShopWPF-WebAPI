using System;

namespace DAL.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IOrdersRepository Orders { get; }

        IProductsCategoriesRepository Categories { get; }

        IProductsRepository Products { get; }

        IStagesRepository Stages { get; }

        void Save();
    }
}
