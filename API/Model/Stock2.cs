using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    public class Stock2
    {
        public int ID { get; set; }
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public double Price { get; set; }
        public long MarketCap { get; set; }
        public string Industry { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}