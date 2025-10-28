using AutoMapper;
using BL.Contracts;
using BL.Dtos;
using DAL.Contracts;
using DAL.Repositiories;
using Domain;

namespace BL.Services
{
    public class RefreshTokenServic : BaseService<TbRefreshTokens,RefreshTokenDto>, IRefreshTokens
    {
        IGenricRepository<TbRefreshTokens> _repo;
        IMapper _mapper;
        public RefreshTokenServic(IGenricRepository<TbRefreshTokens> repo, IMapper mapper,
            IUserService userService) : base(repo, mapper, userService)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<bool> Refresh(RefreshTokenDto tokenDto)
        {
            var tokenList = await _repo.GetList(a => a.UserId == tokenDto.UserId && a.CurrentState == 1);
            foreach (var dbToken in tokenList)
            {
                _repo.ChangeStatus(dbToken.Id, Guid.Parse(tokenDto.UserId), 2);
            }

            var dbTokens = _mapper.Map<RefreshTokenDto, TbRefreshTokens>(tokenDto);
            _repo.Add(dbTokens);
            return true;
        }
    }
}
