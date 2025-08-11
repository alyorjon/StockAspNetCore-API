using API.DTOs.Stock;
using API.Model;

namespace API.Interfaces.Stocks
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stock);
        Task<Stock?> UpdateAsync(int id, UpdateStockDto updateStockDto);
        Task<Stock?> DeleteByIdAsync(int id);   
    }
}