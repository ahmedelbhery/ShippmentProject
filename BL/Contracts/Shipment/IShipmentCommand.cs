using BL.Contracts;
using BL.Dtos;
using Domain;

namespace BL.Contract
{
    public interface IShipmentCommand : IBaseService<TbShipment,ShipmentDto>
    {
        public Task Create(ShipmentDto dto);
        public Task Edit(ShipmentDto dto);
        public Task EditFields(Guid id, Action<TbShipment> updateAction);
    }
}
