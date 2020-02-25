using System;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces.Services
{
    public interface IOrdersService : IDisposable
    {
        IEnumerable<OrderDto> GetAllOrders();

        IEnumerable<StageDto> GetAllOrderStages();

        StageDto GetStageById(int id);

        void AddStage(StageDto stage);
    }
}
