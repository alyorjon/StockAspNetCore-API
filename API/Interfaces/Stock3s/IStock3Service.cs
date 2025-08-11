using API.DTOs;

namespace API.Interfaces.Stock3s
{
    public interface IStock3Service
    {
        Task<List<Stock3Dto>> GetAll();
        Task<Stock3Dto?> GetById(int id);
        Task<Stock3Dto> Create(CreateStock3Dto stock3Dto);
        Task<Stock3Dto?> Update(int id, UpdateStock3Dto updateStock3Dto);
        Task<bool> DeleteById(int id);
    }
}