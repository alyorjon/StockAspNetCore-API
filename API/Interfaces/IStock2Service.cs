using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;

namespace API.Interfaces
{
    public interface IStock2Service
    {
        Task<List<Stock2Dto>> GetAll();
        Task<Stock2Dto?> GetById(int id);
        Task<Stock2Dto> Create(CreateStock2Dto dto);
        Task<Stock2Dto?> Update(int id, UpdateStock2Dto dto);
        Task<bool> DeleteById(int id);
    }
}