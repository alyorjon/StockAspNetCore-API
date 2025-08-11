using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    public class Stock3
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public string Industry { get; set; }
        public decimal Price { get; set; }
        public long MarketCap { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}