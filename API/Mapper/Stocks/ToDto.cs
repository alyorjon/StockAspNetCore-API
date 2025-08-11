
using API.DTOs;
using API.Model;

namespace API.Mapper.Stocks
{
    public static class ToStock
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Price = stockModel.Price,
                MarketCap = stockModel.MarketCap,
                Industry = stockModel.Industry,
                LastUpdated = stockModel.LastUpdated
            };
        }
    }
}