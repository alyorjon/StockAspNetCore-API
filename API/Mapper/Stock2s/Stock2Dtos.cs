
using API.DTOs;
using API.Model;

namespace API.Mapper.Stock2s
{
    public static class ToStock2Dto
    {
        public static Stock2Dto ToStock2Dtos(this Stock2 stock2Dto)
        {
            return new Stock2Dto
            {
                Id = stock2Dto.ID,
                Symbol = stock2Dto.Symbol,
                CompanyName = stock2Dto.CompanyName,
                Price = stock2Dto.Price,
                MarketCap = stock2Dto.MarketCap,
                Industry = stock2Dto.Industry
            };
        }
        public static Stock2 ToStock2Model(this CreateStock2Dto createStock2Dto)
        {
            return new Stock2
            {
                Symbol = createStock2Dto.Symbol,
                CompanyName = createStock2Dto.CompanyName,
                Price = createStock2Dto.Price,
                MarketCap = createStock2Dto.MarketCap,
                Industry = createStock2Dto.Industry
            };
        }
    }
}