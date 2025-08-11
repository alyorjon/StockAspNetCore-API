
using API.DTOs;
using API.Model;

namespace API.Interfaces.Stock3s
{
    public interface IStock3Repository
    {
        Task<List<Stock3>> GetAll();

        Task<Stock3?> GetBySymbolAsync(string symbol);

        Task<Stock3?> GetByCompanyNameAsync(string companyName);

        Task<List<Stock3>?> GetByPriceRangeAsync(decimal min, decimal max);
        Task<List<Stock3>?> GetByPriceTopAsync(int count);
        Task<(List<Stock3>?,int)> GetByPagination(int page, int pageSize, string sortBy);
        Task<Stock3?> GetById(int id);
        Task<Stock3> Create(Stock3 stock3);
        Task<Stock3?> UpdateByID(int id, UpdateStock3Dto dto);
        Task<Stock3?> DeleteById(int id);

    }
}