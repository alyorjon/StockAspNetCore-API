using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Model;

namespace API.Interfaces
{
    public interface IStock2Repository
    {
        Task<List<Stock2>> GetAll();
        Task<Stock2?> GetById(int id);
        Task<Stock2> Create(Stock2 stock2);
        Task<Stock2?> UpdateByID(int id,UpdateStock2Dto updateStock2Dto);
        Task<bool?> DeleteById(int id);
    }
}