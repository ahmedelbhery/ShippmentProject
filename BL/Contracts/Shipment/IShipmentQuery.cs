using BL.Contracts;
using BL.Dtos;
using BL.Services;
using DAL.Models;
using Domain;

namespace BL.Contract
{
    public interface IShipmentQuery : IBaseService<TbShipment,ShipmentDto>
    {
        public Task<List<ShipmentDto>> GetShipments();
        public Task<PagedResult<ShipmentDto>> GetShipments(int pageNumber, int pageSize,bool isUserData,ShipmentStatusEnum? status);
        public Task<PagedResult<ShipmentDto>> GetAllShipments(int pageNumber, int pageSize);
        public Task<ShipmentDto> GetShipment(Guid id);
    }
}
