using AutoMapper;
using BL.Contracts;
using BL.Dtos;
using DAL.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ShippingTypeService : BaseService<TbShipingType,ShipingTypeDto>, IShippingType
    {
        public ShippingTypeService(IGenricRepository<TbShipingType> repo, IMapper mapper, IUserService userService) : base(repo,mapper,userService)
        {
            
        }
    }
}
