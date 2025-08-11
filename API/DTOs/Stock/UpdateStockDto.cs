using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.Stock
{
    public class UpdateStockDto
    {
        public string? Symbol { get; set; }
        public string? CompanyName { get; set; }
        public double? Price { get; set; }
        public long? MarketCap { get; set; }
        public string? Industry { get; set; }
    }
}