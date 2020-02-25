using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.DTO;
using BLL.Exceptions;
using BLL.Interfaces.Services;
using BLL.Services.Abstract;
using DAL.Abstract;
using DAL.DataEntities;
using Ninject;

namespace BLL.Services
{
    /// <summary>
    /// Class representing service to work with orders.
    /// </summary>
    public class OrdersService : BaseService, IOrdersService
    {
        /// <summary>
        /// Creates instance of orders service.
        /// </summary>
        /// <param name="dbUnitOfWork">Instance of unit of work.</param>
        public OrdersService([Named("DB")]IUnitOfWork dbUnitOfWork)
            : base(dbUnitOfWork)
        { }

        /// <summary>
        /// Method to get all stored orders.
        /// </summary>
        /// <returns>List of orders.</returns>
        public IEnumerable<OrderDto> GetAllOrders()
        {
            var resultFromDb = DbUnitOfWork.Orders.GetAll().ToList();

            if (!resultFromDb.Any())
                throw new FailedToFindException("Orders not found");

            return Mapper.Map<IEnumerable<Order>, IEnumerable<OrderDto>>(resultFromDb);
        }

        /// <summary>
        /// Method to get all stored order stages.
        /// </summary>
        /// <returns>List of orders stages.</returns>
        public IEnumerable<StageDto> GetAllOrderStages()
        {
            var resultFromDb = DbUnitOfWork.Stages.GetAll().ToList();

            if (!resultFromDb.Any())
                throw new FailedToFindException("Stages not found");

            return Mapper.Map<IEnumerable<Stage>, IEnumerable<StageDto>>(resultFromDb);
        }

        /// <summary>
        /// Method to get order stage by id.
        /// </summary>
        /// <param name="id">Stage id.</param>
        /// <returns></returns>
        public StageDto GetStageById(int id)
        {
            var resultFromDb = DbUnitOfWork.Stages.GetById(id);
            if (resultFromDb == null)
                throw new FailedToFindException("Stages not found");

            return Mapper.Map<Stage, StageDto>(resultFromDb);
        }

        public void AddStage(StageDto stage)
        {
            DbUnitOfWork.Stages.Add(Mapper.Map<StageDto, Stage>(stage));

            DbUnitOfWork.Stages.SaveChanges();
        }
    }
}
