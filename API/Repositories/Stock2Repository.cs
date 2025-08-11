using API.Data;
using API.DTOs;
using API.Interfaces;
using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class Stock2Repository : IStock2Repository
    {
        private readonly ApplicationDbContext _context;
        public Stock2Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Stock2>> GetAll()
        {
            return await _context.Stock2s.ToListAsync();
        }

        public Task<Stock2?> GetById(int id)
        {
            return _context.Stock2s.FirstOrDefaultAsync(x => x.ID == id);
        }
        public async Task<Stock2> Create(Stock2 stock2)
        {
            await _context.AddAsync(stock2);
            await _context.SaveChangesAsync();
            return stock2;
        }

        public async Task<Stock2?> UpdateByID(int id, UpdateStock2Dto updateStock2Dto)
        {
            var existingStock2 = await _context.Stock2s.FirstOrDefaultAsync(x => x.ID == id);
            if (existingStock2 == null)
                return null;
            if (!string.IsNullOrWhiteSpace(updateStock2Dto.Symbol))
                existingStock2.Symbol = updateStock2Dto.Symbol;
            if (!string.IsNullOrWhiteSpace(updateStock2Dto.CompanyName))
                existingStock2.CompanyName = updateStock2Dto.CompanyName;
            if (!string.IsNullOrWhiteSpace(updateStock2Dto.Industry))
                existingStock2.Industry = updateStock2Dto.Industry;
            if (updateStock2Dto.MarketCap.HasValue)
                existingStock2.MarketCap = updateStock2Dto.MarketCap.Value;
            if (updateStock2Dto.Price.HasValue)
                existingStock2.Price = updateStock2Dto.Price.Value;
            existingStock2.LastUpdated = DateTime.Now;
            await _context.SaveChangesAsync();
            return existingStock2;
        }
        public async Task<bool?> DeleteById(int id)
        {
            var existingStock2 = _context.Stock2s.FirstOrDefault(x => x.ID == id);
            if (existingStock2 == null)
                return false;
            _context.Remove(existingStock2);
            await _context.SaveChangesAsync();
            return true; 
        }

    }
}