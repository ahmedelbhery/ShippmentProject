using BL.Contracts;
using BL.Dtos;
using DAL.Exeptions;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingTypesController : ControllerBase
    {
        private readonly IShippingType _shippingType;
        public ShippingTypesController(IShippingType shippingType)
        {
            _shippingType = shippingType;
        }

        // GET: api/<ShippingTypesController>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<ShipingTypeDto>>>> GetAsync()
        {
            try
            {
                var data = await _shippingType.GetAll();
                return Ok(ApiResponse<List<ShipingTypeDto>>.SuccessResponse(data));
            }
            catch (DataAccessException daEx)
            {
                return StatusCode(500, ApiResponse<List<ShipingTypeDto>>
                                .FailResponse("data access exception", new List<string>() { daEx.Message }));
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ApiResponse<List<ShipingTypeDto>>
                                .FailResponse("general exception", new List<string>() { ex.Message }));
            }
        }

        // GET api/<ShippingTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ShipingTypeDto>>> GetAsync(Guid id)
        {
            try
            {
                var data = await _shippingType.GetById(id);
                return Ok(ApiResponse<ShipingTypeDto>.SuccessResponse(data));
            }
            catch (DataAccessException daEx)
            {
                return StatusCode(500, ApiResponse<ShipingTypeDto>
                                .FailResponse("data access exception", new List<string>() { daEx.Message }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<ShipingTypeDto>
                                .FailResponse("general exception", new List<string>() { ex.Message }));
            }
        }

    }
}
