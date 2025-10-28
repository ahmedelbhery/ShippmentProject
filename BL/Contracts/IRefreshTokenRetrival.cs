using BL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contracts
{
    public interface IRefreshTokenRetrival
    {
        public Task<RefreshTokenDto> GetByToken(string token);
    }
}
