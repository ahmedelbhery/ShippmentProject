using BL.Contracts;
using BL.Dtos;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UI.Helpers;

namespace UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class CountriesController : Controller
    {
        private readonly ICountry _ICountry;
        public CountriesController(ICountry country)
        {
            _ICountry=country;
        }
        public async Task<IActionResult> Index()
        {
            var data =await _ICountry.GetAll();
            return View(data);
        }

        public  async Task<IActionResult> Edit(Guid? Id)
        {
            TempData["MessageType"] = null;
            var data=new CountryDto(); 
            if (Id != null)
            {
                data =await _ICountry.GetById((Guid)Id);
            }
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(CountryDto data)
        {
            TempData["MessageType"] = null;

            if (!ModelState.IsValid)
                return View("Edit", data);

            try
            {
                if (data.Id == Guid.Empty)
                   await _ICountry.Add(data);
                else
                    await _ICountry.Update(data);
                TempData["MessageType"] = MessageTypes.SaveSuccess;
            }
            catch (Exception ex) 
            {
                TempData["MessageType"] = MessageTypes.SaveFailed;
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
            TempData["MessageType"] = null;
            try
            {
                await _ICountry.ChangeStatus(Id, 0);
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
