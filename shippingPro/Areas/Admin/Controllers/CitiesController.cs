using BL.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Helpers;
using BL.Contracts;
using System.Threading.Tasks;
namespace UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class CitiesController : Controller
    {
        private readonly ICity _ICity;
        private readonly ICountry _ICountry;
        public CitiesController(ICity ICity, ICountry iCountry)
        {
            _ICity = ICity;
            _ICountry = iCountry;
        }
        public async Task<IActionResult> Index()
        {
            var data =await _ICity.GetAllCitites();
            return View(data);
        }

        public async Task<IActionResult> Edit(Guid? Id)
        {
            TempData["MessageType"] = null;
            var data=new CityDto();
            LoadCountries();
            if (Id != null)
            {
                data =await  _ICity.GetById((Guid)Id);
            }
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(CityDto data)
        {
            TempData["MessageType"] = null;
            if (!ModelState.IsValid)
            {
                LoadCountries();
                return View("Edit", data);
            }

            try
            {
                if (data.Id == Guid.Empty)
                    await _ICity.Add(data);
                else
                    await _ICity.Update(data);
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
                _ICity.ChangeStatus(Id, 0);
                TempData["MessageType"] = MessageTypes.DeleteSuccess;
            }
            catch (Exception ex)
            {
                TempData["MessageType"] = MessageTypes.DeleteFailed;
            }

            return RedirectToAction("Index");
        }

        void LoadCountries()
        {
            var countries = _ICountry.GetAll();
            ViewBag.Countries = countries;
        }
    }
}
