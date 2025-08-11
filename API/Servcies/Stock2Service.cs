using API.DTOs;
using API.Interfaces;
using API.Mapper.Stock2s;

namespace API.Servcies
{
    public class Stock2Service : IStock2Service
    {

        private readonly IStock2Repository _stock2Repository;
        public Stock2Service(IStock2Repository stock2Repository)
        {
            _stock2Repository = stock2Repository;
        }
        public async Task<List<Stock2Dto>> GetAll()
        {
            var stocks = await _stock2Repository.GetAll();
            return stocks.Select(x => x.ToStock2Dtos()).ToList();
        }

        public async Task<Stock2Dto?> GetById(int id)
        {
            var stock2 = await _stock2Repository.GetById(id);
            if (stock2 == null)
                return null;
            return stock2.ToStock2Dtos();
        }
        public async Task<Stock2Dto> Create(CreateStock2Dto dto)
        {
            var stock2Model = dto.ToStock2Model();
            var stock2 = await _stock2Repository.Create(stock2Model);
            return stock2.ToStock2Dtos();
        }

        public async Task<Stock2Dto?> Update(int id, UpdateStock2Dto dto)
        {
            var stockModel = await _stock2Repository.UpdateByID(id, dto);
            if (stockModel == null)
                return null;
            return stockModel.ToStock2Dtos();
        }

        public async Task<bool> DeleteById(int id)
        {
            var deletedStock2 = await _stock2Repository.DeleteById(id);
            if (deletedStock2 == null)
                return false;
            return true;
        }

    }
}