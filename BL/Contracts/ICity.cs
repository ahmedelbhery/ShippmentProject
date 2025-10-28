using BL.Dtos;
using Domain;

namespace BL.Contracts
{
    public interface ICity : IBaseService<TbCity,CityDto>
    {
        Task<List<CityDto>> GetAllCitites();

        Task<List<CityDto>> GetByCountry(Guid countryId);

    }
}
