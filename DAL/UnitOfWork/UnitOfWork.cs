using System;
using DAL.Abstract;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IShopDbContext _context;

        public IOrdersRepository Orders { get; private set; }

        public IProductsCategoriesRepository Categories { get; private set; }

        public IProductsRepository Products { get; private set; }

        public IStagesRepository Stages { get; private set; }

        public UnitOfWork(
            IShopDbContext context,
            IOrdersRepository orders,
            IProductsCategoriesRepository categories,
            IProductsRepository products,
            IStagesRepository stages
            )
        {
            _context = context;
            Orders = orders;
            Categories = categories;
            Products = products;
            Stages = stages;
            _isDisposed = false;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _isDisposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposing)
        {
            if (_isDisposed)
                return;

            if (isDisposing)
            {
                Orders = null;
                Categories = null;
                Products = null;
                Stages = null;
            }

            _context.Dispose();
            _context = null;
            _isDisposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
