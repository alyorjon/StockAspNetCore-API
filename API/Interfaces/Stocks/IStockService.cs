

using API.DTOs;
using API.DTOs.Stock;

namespace API.Interfaces.Stocks
{
    public interface IStockService
    {
        Task<List<StockDto>> GetAllAsync();
        Task<StockDto?> GetByIdAsync(int id);
        Task<StockDto> CreateAsync(CreateStockDto createStockDto);
        Task<StockDto?> UpdateAsync(int id, UpdateStockDto updateStockDto);
        Task<bool?> DeleteByIdAsync(int id);
    }
}