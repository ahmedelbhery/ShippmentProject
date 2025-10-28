using BL.Contracts;
using BL.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UI.Helpers;

namespace UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class ShippingPackgingController : Controller
    {
        private readonly IPackgingTypes _packgingTypes;
        public ShippingPackgingController(IPackgingTypes shipingPackage)
        {
            _packgingTypes = shipingPackage;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var data = await _packgingTypes.GetAll();
            return View(data);
        }

        public async Task<IActionResult> Edit(Guid? Id)
        {
            TempData["MessageType"] = null;
            var data=new ShipingPackgingDto(); 
            if (Id != null)
            {
                data =await _packgingTypes.GetById((Guid)Id);
            }
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(ShipingPackgingDto data)
        {
            TempData["MessageType"] = null;

            if (!ModelState.IsValid)
                return View("Edit", data);

            try
            {
                if (data.Id == Guid.Empty)
                    await _packgingTypes.Add(data);
                else
                   await _packgingTypes.Update(data);
                TempData["MessageType"] = MessageTypes.SaveSuccess;
            }
            catch (Exception ex) 
            {
                TempData["MessageType"] = MessageTypes.SaveFailed;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid Id)
        {
            TempData["MessageType"] = null;
            try
            {
                _packgingTypes.ChangeStatus(Id, 0);
                TempData["MessageType"] = MessageTypes.DeleteSuccess;
            }
            catch (Exception ex)
            {
                TempData["MessageType"] = MessageTypes.DeleteFailed;
            }

            return RedirectToAction("Index");
        }
    }
}
