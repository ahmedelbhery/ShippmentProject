using AutoMapper;
using BL.Contracts;
using BL.Dtos;
using DAL.Contracts;
using DAL.Repositiories;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class RefreshTokenRetrievalService : IRefreshTokenRetrival
    {
        IGenricRepository<TbRefreshTokens> _repo;
        IMapper _mapper;
        public RefreshTokenRetrievalService(IGenricRepository<TbRefreshTokens> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<RefreshTokenDto> GetByToken(string token)
        {
            var refreshToken = await _repo.GetFirstOrDefault(a => a.Token == token);
            return _mapper.Map<TbRefreshTokens, RefreshTokenDto>(refreshToken);
        }
    }
}
