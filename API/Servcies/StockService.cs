using API.DTOs;
using API.DTOs.Stock;
using API.Interfaces.Stocks;
using API.Mapper.Stocks;

namespace API.Servcies
{

    public  class StockService : IStockService
    {
        public IStockRepository _stockRepository;
        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }


        public async Task<List<StockDto>> GetAllAsync()
        {
            var response = await _stockRepository.GetAllAsync();
            return response.Select(x => x.ToStockDto()).ToList();
        }

        public async Task<StockDto?> GetByIdAsync(int id)
        {
            var response = await _stockRepository.GetByIdAsync(id);
            if (response == null)
                return null;
            return response.ToStockDto();
        }
        public async Task<StockDto> CreateAsync(CreateStockDto createStockDto)
        {
            var stockModel = createStockDto.ToStockModel();
            var createdStock = await _stockRepository.CreateAsync(stockModel);
            return createdStock.ToStockDto();
            
        }
        public async Task<StockDto?> UpdateAsync(int id, UpdateStockDto updateStockDto)
        {
            var updatedStock = await _stockRepository.UpdateAsync(id, updateStockDto);
            if (updatedStock == null)
                return null;
            return updatedStock.ToStockDto();
        }


        public async Task<bool?> DeleteByIdAsync(int id)
        {
            var deletedStock = await _stockRepository.DeleteByIdAsync(id);
            if (deletedStock == null)
                return false;
            return true;
        }
    }

}
