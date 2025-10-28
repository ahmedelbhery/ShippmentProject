using AutoMapper;
using BL.Contracts;
using BL.Dtos;
using DAL.Contracts;
using DAL.Repositiories;
using Domain;

namespace BL.Services
{
    public class CityService : BaseService<TbCity, CityDto>, ICity
    {
        IViewRepository<VwCities> _ViewRepo;
        IMapper _mapper;
        public CityService(IGenricRepository<TbCity> repo, IMapper mapper,
            IUserService userService, IViewRepository<VwCities> viewRepo) : base(repo, mapper, userService)
        {
            _ViewRepo = viewRepo;
            _mapper = mapper;
        }

        public async Task<List<CityDto>> GetAllCitites()
        {
            var cities = await _ViewRepo.GetList(a => a.CurrentState == 1);
            return _mapper.Map<List<VwCities>, List<CityDto>>(cities);
        }

        public async Task<List<CityDto>> GetByCountry(Guid countryId)
        {
            var cities = await _ViewRepo.GetList(a => a.CurrentState == 1 &&
            a.CountryId == countryId);
            return _mapper.Map<List<VwCities>, List<CityDto>>(cities);
        }
    }
}
