using BL.Contract;
using BL.Contracts;
using BL.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UI.Controllers
{
    public class ShipmentsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IShipmentQuery _IShipment;
        public ShipmentsController(ILogger<HomeController> logger, IShipmentQuery iGenericRepository)
        {
            _logger = logger;
            _IShipment = iGenericRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {


            return View();
        }

        public async Task<IActionResult> List(int page=1)
        {
            ShipmentStatusEnum? status = ShipmentStatusEnum.Created;
            if (User.IsInRole("Admin"))
                status = null;
            else if (User.IsInRole("Reviewer"))
                status = ShipmentStatusEnum.Created;
            else if (User.IsInRole("Operation"))
                status = ShipmentStatusEnum.Approved;
            else if (User.IsInRole("Operation Manager"))
                status = ShipmentStatusEnum.ReadyForShip;
            var shipments = await _IShipment.GetShipments(page,10, false, status);
            return View(shipments);
        }

        public IActionResult Show(Guid id)
        {
            return View();
        }

        public IActionResult Edit(Guid id)
        {
            return View();
        }

        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _IShipment.ChangeStatus(id, 0);
            return RedirectToAction("List");
        }
    }
}
