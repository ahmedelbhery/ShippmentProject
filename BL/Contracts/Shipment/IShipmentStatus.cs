using BL.Contracts;
using BL.Dtos;
using BL.Services;
using DAL.Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contract
{
    public interface IShipmentStatus : IBaseService<TbShipmentStatus,ShipmentStatusDto>
    {
        public Task<(bool, Guid)> Add(Guid shipmentId, ShipmentStatusEnum status);
    }
}
