using BL.Contract;
using BL.Contract.Shipment;
using BL.Contracts;
using BL.Dtos;
using BL.Services;
using DAL.Exeptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Models;



namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]   
    public class ShipmentController : ControllerBase
    {
        IShipmentCommand _shipment;
        IShipmentQuery _shipmentQuery;
        IUserService _userService;
        IShipmentStateHandlerFactory _shipmentStateHandlerFactory;
        public ShipmentController(IShipmentCommand shipment, IShipmentQuery shipmentQuery,
            IUserService userService, IShipmentStateHandlerFactory shipmentStateHandlerFactory)
        {
            _shipment = shipment;
            _userService = userService;
            _shipmentStateHandlerFactory = shipmentStateHandlerFactory;
            _shipmentQuery = shipmentQuery;
        }
        // GET: api/<ShipmentController>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<ShipmentDto>>>> Get()
        {
            try
            {
                var data = await _shipmentQuery.GetShipments(); // أو _repo.GetShipments() حسب مكان التنفيذ

                return Ok(ApiResponse<List<ShipmentDto>>.SuccessResponse(data));
            }
            catch (DataAccessException daEx)
            {
                return StatusCode(500, ApiResponse<List<ShipmentDto>>.FailResponse(
                    "data access exception",
                    new List<string> { daEx.Message }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<List<ShipmentDto>>.FailResponse(
                    "general exception",
                    new List<string> { ex.Message }));
            }
        }

        // GET api/<ShipmentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ShipmentDto>>> Get(Guid id)
        {
            try
            {
                var data = await _shipmentQuery.GetShipment(id); // أو _repo.GetShipments() حسب مكان التنفيذ

                return Ok(ApiResponse<ShipmentDto>.SuccessResponse(data));
            }
            catch (DataAccessException daEx)
            {
                return StatusCode(500, ApiResponse<ShipmentDto>.FailResponse(
                    "data access exception",
                    new List<string> { daEx.Message }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<ShipmentDto>.FailResponse(
                    "general exception",
                    new List<string> { ex.Message }));
            }
        }

        [HttpPost("Create")]  // api/Shipment/Create
        public async Task<IActionResult> Create([FromBody] ShipmentDto data)
        {
            if (data == null)
            {
                return BadRequest(ApiResponse<string>.FailResponse("Shipment data is required."));
            }

            try
            {
                await _shipment.Create(data);

                return Ok(ApiResponse<object>.SuccessResponse("", "Shipment created successfully."));
            }
            catch (Exception ex)
            {
                var errors = new List<string> { ex.Message };
                return StatusCode(500, ApiResponse<string>.FailResponse("An error occurred while creating the shipment.", errors));
            }
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit([FromBody] ShipmentDto data)
        {
            if (data == null)
            {
                return BadRequest(ApiResponse<string>.FailResponse("Shipment data is required."));
            }

            try
            {
                await _shipment.Edit(data);

                return Ok(ApiResponse<object>.SuccessResponse("", "Shipment Updated successfully."));
            }
            catch (Exception ex)
            {
                var errors = new List<string> { ex.Message };
                return StatusCode(500, ApiResponse<string>.FailResponse("An error occurred while Update the shipment.", errors));
            }
        }

        [HttpPost("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus([FromBody] ShipmentDto data)
        {
            if (data == null)
            {
                return BadRequest(ApiResponse<string>.FailResponse("Shipment data is required."));
            }

            try
            {
                ShipmentStatusEnum targetStatus = (ShipmentStatusEnum)data.CurrentState;

                var result = _shipmentStateHandlerFactory.GetHandler(targetStatus);
                await result.HandleState(data);

                return Ok(ApiResponse<object>.SuccessResponse(result, "Shipment Change Status successfully."));
            }
            catch (Exception ex)
            {
                var errors = new List<string> { ex.Message };
                return StatusCode(500, ApiResponse<string>.FailResponse("An error occurred while Change Status the shipment.", errors));
            }
        }

    }
}
