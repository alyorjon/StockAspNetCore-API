
using API.DTOs;
using API.Model;

namespace API.Interfaces.Stock3s
{
    public interface IStock3Repository
    {
        Task<List<Stock3>> GetAll();
        Task<Stock3?> GetById(int id);
        Task<Stock3> Create(Stock3 stock3);
        Task<Stock3?> UpdateByID(int id, UpdateStock3Dto dto);
        Task<Stock3?> DeleteById(int id);

    }
}