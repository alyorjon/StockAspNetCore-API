using API.Data;
using API.DTOs;
using API.Interfaces.Stock3s;
using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class Stock3Repository : IStock3Repository
    {
        private readonly ApplicationDbContext _context;
        public Stock3Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Stock3>> GetAll()
        {
            return await _context.Stock3s.ToListAsync();
        }

        public async Task<Stock3> Create(Stock3 stock3)
        {
            await _context.AddAsync(stock3);
            await _context.SaveChangesAsync();
            return stock3;
        }

        public async Task<Stock3?> GetById(int id)
        {
            var existing = await _context.Stock3s.FirstOrDefaultAsync(x => x.Id == id);
            if (existing == null)
                return null;
            return existing;
        }

        public async Task<Stock3?> UpdateByID(int id, UpdateStock3Dto dto)
        {
            var existing = await _context.Stock3s.FirstOrDefaultAsync(x => x.Id == id);
            if (existing == null) return null;
            if (!string.IsNullOrEmpty(dto.Symbol)) existing.Symbol = dto.Symbol;
            if (!string.IsNullOrEmpty(dto.CompanyName)) existing.CompanyName = dto.CompanyName;
            if (!string.IsNullOrEmpty(dto.Industry)) existing.Industry = dto.Industry;
            if (dto.Price.HasValue) existing.Price = dto.Price.Value;
            if (dto.MarketCap.HasValue) existing.MarketCap = dto.MarketCap.Value;
            existing.LastUpdated = DateTime.UtcNow;
            _context.SaveChanges();
            return existing;
        }

        public async Task<Stock3?> DeleteById(int id)
        {
            var existing = await _context.Stock3s.FirstOrDefaultAsync(x => x.Id == id);
            if (existing == null) return null;
            _context.Remove(existing);
            await _context.SaveChangesAsync();
            return existing;
        }

    }
}