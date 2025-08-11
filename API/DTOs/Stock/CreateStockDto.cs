

namespace API.DTOs.Stock
{
    public class CreateStockDto
    {
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public double Price { get; set; }
        public long MarketCap { get; set; }
        public string Industry { get; set; }
    }
}