using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contracts
{
    public interface IBaseService<T,DTO> where T : class
    {
        Task<List<DTO>> GetAll();
        Task<DTO> GetById(Guid id);
        Task<(bool, Guid)> Add(DTO entity);
        Task<bool> Update(DTO entity);
        Task<bool> ChangeStatus(Guid id, int status = 1);
    }
}
