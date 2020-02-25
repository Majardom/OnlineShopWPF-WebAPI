using DAL.Abstract;
using System;

namespace BLL.Services.Abstract
{
    /// <summary>
    /// Class containing logic for base service. 
    /// </summary>
    public class BaseService
    {
        /// <summary>
        /// Instance of unit of work for data base.
        /// </summary>
        protected IUnitOfWork DbUnitOfWork;

        /// <summary>
        /// Instance of unit of work for serialization.
        /// </summary>
        protected IUnitOfWork SerJsonUnitOfWork;

        /// <summary>
        /// Instance of unit of work for serialization.
        /// </summary>
        protected IUnitOfWork SerXmlUnitOfWork;

        /// <summary>
        /// Instance of unit of work for serialization.
        /// </summary>
        protected IUnitOfWork SerDataContractUnitOfWork;

        /// <summary>
        /// Creates instance of base service
        /// </summary>
        /// <param name="dbUnitOfWork">Instance of unit of work.</param>
        public BaseService(IUnitOfWork dbUnitOfWork)
        {
            DbUnitOfWork = dbUnitOfWork
                ?? throw new ArgumentNullException(nameof(dbUnitOfWork));

            _isDisposed = false;
        }

        public BaseService(IUnitOfWork dbUnitOfWork, 
            IUnitOfWork serJsonUnitOfWork,
            IUnitOfWork serXmlUnitOfWork,
            IUnitOfWork serDataContractUnitOfWork)
            :this(dbUnitOfWork)
        {
            SerJsonUnitOfWork = serJsonUnitOfWork
                ?? throw new ArgumentNullException(nameof(serJsonUnitOfWork));

            SerXmlUnitOfWork = serXmlUnitOfWork
               ?? throw new ArgumentNullException(nameof(serXmlUnitOfWork));

            SerDataContractUnitOfWork = serDataContractUnitOfWork
               ?? throw new ArgumentNullException(nameof(serDataContractUnitOfWork));

            _isDisposed = false;
        }

        /// <summary>
        /// Method to save changes.
        /// </summary>
        public void ApplyChanges()
        {
            DbUnitOfWork.Save();
        }

        /// <summary>
        /// Variable containing information weather object has been already disposed.
        /// </summary>
        private bool _isDisposed;

        /// <summary>
        /// Method to release unmanaged resources. 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Method to release unmanaged resources. 
        /// </summary>
        /// <param name="isDisposing">Describes weather method is called from finalizer or manually.</param>
        protected void Dispose(bool isDisposing)
        {
            if (_isDisposed) return;

            if (isDisposing) { }

            DbUnitOfWork.Dispose();
            DbUnitOfWork = null;
            _isDisposed = true;
        }
    }
}
