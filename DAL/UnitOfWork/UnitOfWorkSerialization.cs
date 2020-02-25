using System;
using DAL.Abstract;

namespace DAL.UnitOfWork
{
    public class UnitOfWorkSerialization : IUnitOfWork, IDisposable
    {
        private ISerializer _serializer;

        public IOrdersRepository Orders { get; private set; }

        public IProductsCategoriesRepository Categories { get; private set; }

        public IProductsRepository Products { get; private set; }

        public IStagesRepository Stages { get; private set; }

        public UnitOfWorkSerialization(
            ISerializer serializer,
            IOrdersRepository orders,
            IProductsCategoriesRepository categories,
            IProductsRepository products,
            IStagesRepository stages
            )
        {
            _serializer = serializer;
            Orders = orders;
            Categories = categories;
            Products = products;
            Stages = stages;
        }

        public void Save()
        {
            _serializer.Save(Products.GetAll());
            _serializer.Save(Orders.GetAll());
            _serializer.Save(Categories.GetAll());
            _serializer.Save(Stages.GetAll());
            _isDisposed = false;

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

            _serializer = null;
            _isDisposed = true;
        }

        ~UnitOfWorkSerialization()
        {
            Dispose(false);
        }
    }
}
