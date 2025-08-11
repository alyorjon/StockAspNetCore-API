using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class Stock3Dto
    {
        public int id { get; set; }
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public string Industry { get; set; }
        public double Price { get; set; }
        public long MarketCap { get; set; }
        public DateTime LastUpdated { get; set; }
    }
    public class CreateStock3Dto
    {
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public string Industry { get; set; }
        public double Price { get; set; }
        public long MarketCap { get; set; }

    }
    public class UpdateStock3Dto
    {
        public string? Symbol { get; set; }
        public string? CompanyName { get; set; }
        public string? Industry { get; set; }
        public double? Price { get; set; }
        public long? MarketCap { get; set; }
     
    }
}