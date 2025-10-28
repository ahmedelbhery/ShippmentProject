using BL.Contract;
using BL.Contracts;
using BL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class ShipmentController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IShipmentQuery _IShipment;

        public ShipmentController(ILogger<HomeController> logger, IShipmentQuery iShipment)
        {
            _logger = logger;
            _IShipment = iShipment;
        }

        public async Task<IActionResult> Index(int page = 1)
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

            var shipments = await _IShipment.GetShipments(page, 10, false, status);
            return View(shipments);
        }

        public IActionResult Edit(Guid? id)
        {
            return View();
        }
    }
}
