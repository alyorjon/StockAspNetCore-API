
using API.DTOs;
using API.Interfaces.Stock3s;
using API.Mapper;
using API.Model;

namespace API.Servcies
{
    public class Stock3Service : IStock3Service
    {

        public IStock3Repository _stock3Repository; 
        public Stock3Service(IStock3Repository stock3Repository)
        {
            _stock3Repository = stock3Repository;
        }
        public async Task<List<Stock3Dto>> GetAll()
        {
            var stock3s = await _stock3Repository.GetAll();
            return stock3s.Select(stock3 => stock3.ToStock3Dto()).ToList();
        }

        public async Task<Stock3Dto?> GetBySymbolAsync(string symbol)
        {
            var response = await _stock3Repository.GetBySymbolAsync(symbol);
            if (response == null) return null;
            return response.ToStock3Dto();
        }


        public async Task<Stock3Dto> Create(CreateStock3Dto stock3Dto)
        {
            var stock3 = stock3Dto.ToStock3Model();
            await _stock3Repository.Create(stock3);
            return stock3.ToStock3Dto();
        }

        public async Task<Stock3Dto?> GetByCompanyNameAsync(string companyName)
        {
            var response = await _stock3Repository.GetByCompanyNameAsync(companyName);
            if (response == null) return null;
            return response.ToStock3Dto();
        }

        public async Task<List<Stock3Dto>?> GetByPriceRangeAsync(decimal min, decimal max)
        {
            var response = await _stock3Repository.GetByPriceRangeAsync(min, max);
            if (response == null) return null;
            return response.Select(x => x.ToStock3Dto()).ToList();
        }

        public async Task<List<Stock3Dto>?> GetByPriceTopAsync(int count)
        {
            var response = await _stock3Repository.GetByPriceTopAsync(count);
            if (response == null) return null;
            return response.Select(x => x.ToStock3Dto()).ToList();
        }

        public async Task<PagedResult<Stock3Dto>> GetByPagination(int page, int pageSize, string sortBy = "id")
        {
            var response = await _stock3Repository.GetByPagination(page, pageSize, sortBy);
            
            return new PagedResult<Stock3Dto>
                {
                    Items = (response.Item1 ?? new List<Stock3>())
                                .Select(x => x.ToStock3Dto())
                                .ToList(),
                    TotalCount = response.Item2
                };

        }

        public async Task<Stock3Dto?> GetById(int id)
        {
            var existing = await _stock3Repository.GetById(id);
            if (existing == null) return null;
            return existing.ToStock3Dto();
        }

        public async Task<Stock3Dto?> Update(int id, UpdateStock3Dto updateStock3Dto)
        {
            var stock3Model =await _stock3Repository.UpdateByID(id, updateStock3Dto);
            if (stock3Model == null) return null;

            return stock3Model.ToStock3Dto();
        }
        public async Task<bool> DeleteById(int id)
        {
            var deletedStock3 =await _stock3Repository.DeleteById(id);
            if (deletedStock3 == null) return false;
            return true;
        }

    }
}