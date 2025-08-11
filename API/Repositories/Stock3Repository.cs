using API.Data;
using API.DTOs;
using API.Interfaces.Stock3s;
using API.Model;
using Microsoft.AspNetCore.Mvc;
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


        public async Task<Stock3?> GetBySymbolAsync(string symbol)
        {
            return await _context.Stock3s.FirstOrDefaultAsync(x => x.Symbol.ToLower() == symbol.ToLower());
        }

        public async Task<Stock3?> GetByCompanyNameAsync(string companyName)
        {
            return await _context.Stock3s.FirstOrDefaultAsync(x=> x.CompanyName.ToLower().Contains(companyName.ToLower()));
        }

        public async Task<Stock3> Create(Stock3 stock3)
        {
            await _context.AddAsync(stock3);
            await _context.SaveChangesAsync();
            return stock3;
        }


        public async Task<List<Stock3>?> GetByPriceRangeAsync(decimal min, decimal max)
        {
            var response = await _context.Stock3s.Where(x => x.Price >= min && x.Price <= max).ToListAsync();
            if (response == null) return null;
            return response;
        }

        public async Task<List<Stock3>?> GetByPriceTopAsync(int count)
        {
            var response = await _context.Stock3s.OrderByDescending(x =>(decimal)x.Price).Take(count).ToListAsync();
            if (response == null) return null;
            return response;
        }


        public async Task<(List<Stock3>?,int)> GetByPagination(int page, int pageSize, string sortBy = "id")
        {
            var query = _context.Stock3s.AsQueryable();
            query = sortBy.ToLower() switch
            {
                "symbol" => query.OrderBy(x => x.Symbol),
                "companyname" => query.OrderBy(x => x.CompanyName),
                _ => query.OrderBy(x => x.Id)
            };
            var totalCount= await query.CountAsync();
            var response = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            if (response.Count == 0) return (null,totalCount);
            return (response, totalCount);
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

        public async Task<List<Stock3>?> GetBySearchAsync(string search)
        {
            var query = _context.Stock3s.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.Symbol.ToLower().Contains(search.ToLower()) ||
                                         x.CompanyName.ToLower().Contains(search.ToLower())|| x.Industry.ToLower().Contains(search.ToLower()));
            }
            return await query.ToListAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Stock3s.CountAsync();
        }

        public async Task<decimal> GetAveragePriceAsync()
        {
            return await _context.Stock3s.AverageAsync(x=>x.Price);
        }

        public async Task<List<Stock3>?> GetUpdatedInRangeAsync(DateTime start, DateTime end)
        {
            var query = _context.Stock3s.AsQueryable();
            if (start != DateTime.MinValue && end != DateTime.MinValue)
            {
                query = query.Where(x => x.LastUpdated >= start && x.LastUpdated <= end);
                return await query.ToListAsync();
            }
            return await Task.FromResult<List<Stock3>?>(null);
        }
    }
}