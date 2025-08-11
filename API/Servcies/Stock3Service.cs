
using API.DTOs;
using API.Interfaces.Stock3s;
using API.Mapper;

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
        public async Task<Stock3Dto> Create(CreateStock3Dto stock3Dto)
        {
            var stock3 = stock3Dto.ToStock3Model();
            await _stock3Repository.Create(stock3);
            return stock3.ToStock3Dto();
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