using API.DTOs;

namespace API.Interfaces.Stock3s
{
    public interface IStock3Service
    {
        Task<List<Stock3Dto>> GetAll();
        Task<Stock3Dto?> GetBySymbolAsync(string symbol);
        Task<Stock3Dto?> GetByCompanyNameAsync(string companyName);
        Task<List<Stock3Dto>?> GetByPriceRangeAsync(decimal min, decimal max);
        Task<List<Stock3Dto>?> GetByPriceTopAsync(int count);
        Task<PagedResult<Stock3Dto>>    GetByPagination(int page, int pageSize, string sortBy = "id");

        Task<List<Stock3Dto>?> GetBySearchAsync(string search);
        Task<int> GetCountAsync();
        Task<decimal> GetAveragePriceAsync();
        Task<List<Stock3Dto>?> GetUpdatedInRangeAsync(DateTime start, DateTime end);
        Task<Stock3Dto?> GetById(int id);
        Task<Stock3Dto> Create(CreateStock3Dto stock3Dto);
        Task<Stock3Dto?> Update(int id, UpdateStock3Dto updateStock3Dto);
        Task<bool> DeleteById(int id);
    }
}