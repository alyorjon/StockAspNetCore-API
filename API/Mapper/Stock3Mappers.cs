using API.DTOs;
using API.Model;

namespace API.Mapper
{
    public static class Stock3Mappers
    {
        public static Stock3Dto ToStock3Dto(this Stock3 stock3)
        {
            return new Stock3Dto
            {
                id = stock3.Id,
                Symbol = stock3.Symbol,
                CompanyName = stock3.CompanyName,
                Price = stock3.Price,
                MarketCap = stock3.MarketCap,
                Industry = stock3.Industry,
                LastUpdated=stock3.LastUpdated,
            };
        }

        public static Stock3 ToStock3Model(this CreateStock3Dto stock3Dto)
        {
            return new Stock3
            {
                Symbol = stock3Dto.Symbol,
                CompanyName = stock3Dto.CompanyName,
                Price = stock3Dto.Price,
                MarketCap = stock3Dto.MarketCap,
                Industry = stock3Dto.Industry,
                LastUpdated= DateTime.Now,
            };
        }
    }
}