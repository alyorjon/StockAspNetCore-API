using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class Stock2Dto
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public double Price { get; set; }
        public long MarketCap { get; set; }
        public string Industry { get; set; }
    }

    public class CreateStock2Dto
    {
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public double Price { get; set; }
        public long MarketCap { get; set; }
        public string Industry { get; set; }
    }
    public class UpdateStock2Dto
    {
        public string? Symbol { get; set; }
        public string? CompanyName { get; set; }
        public double? Price { get; set; }
        public long? MarketCap { get; set; }
        public string? Industry { get; set; }
    }
}