
using API.Data;
using API.DTOs.Stock;
using API.Interfaces.Stocks;
using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class StockRepository : IStockRepository
    {
        public ApplicationDbContext _context;
        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List< Stock>> GetAllAsync()
        {
            return await _context.Stocks.OrderBy(x=>x.Symbol).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            // return res ;
        }
        public async Task<Stock> CreateAsync(Stock stockModel)
        {

            await  _context.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockDto updateStockDto)
        {
            var existingStock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingStock == null)
                return null;
            if (!string.IsNullOrWhiteSpace(updateStockDto.Symbol))
                existingStock.Symbol = updateStockDto.Symbol;
            if (!string.IsNullOrWhiteSpace(updateStockDto.CompanyName))
                existingStock.CompanyName = updateStockDto.CompanyName;
            if (!string.IsNullOrWhiteSpace(updateStockDto.Industry))
                existingStock.Industry = updateStockDto.Industry;
            if (updateStockDto.MarketCap.HasValue)
                existingStock.MarketCap = updateStockDto.MarketCap.Value;
            if (updateStockDto.Price.HasValue)
                existingStock.Price = updateStockDto.Price.Value;
            existingStock.LastUpdated = DateTime.Now;
            await _context.SaveChangesAsync();
            return existingStock;
        }

        public async Task<Stock?> DeleteByIdAsync(int id)
        {
            var existingStock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingStock == null) return null;
            _context.Remove(existingStock);
            await _context.SaveChangesAsync();
            return existingStock;
        }

    }
}