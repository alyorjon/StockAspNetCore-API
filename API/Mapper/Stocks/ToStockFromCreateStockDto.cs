

using API.DTOs.Stock;
using API.Model;

namespace API.Mapper.Stocks
{
    public static class ToStockFromCreateStockDto
    {
        public static Stock ToStockModel(this CreateStockDto createStockDto)
        {
            return new Stock
            {
                Symbol = createStockDto.Symbol,
                CompanyName = createStockDto.CompanyName,
                Price = createStockDto.Price,
                MarketCap = createStockDto.MarketCap,
                Industry = createStockDto.Industry
            };
        }        
    }
}