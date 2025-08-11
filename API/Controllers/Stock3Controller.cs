
using API.DTOs;
using API.Interfaces.Stock3s;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Stock3Controller : ControllerBase
    {
        public IStock3Service _stock3Service;
        public Stock3Controller(IStock3Service stock3Service)
        {
            _stock3Service = stock3Service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stock3s = await _stock3Service.GetAll();
            return Ok(stock3s);
        }

        [HttpGet("symbol/{symbol}")]
        public async Task<IActionResult> GetBySymbolAsync([FromRoute] string symbol)
        {
            var response = await _stock3Service.GetBySymbolAsync(symbol);
            return Ok(response);
        }

        [HttpGet("companyName/{companyName}")]
        public async Task<IActionResult> GetByCompanyNameAsync([FromRoute] string companyName)
        {
            var response = await _stock3Service.GetByCompanyNameAsync(companyName);
            return Ok(response);
        }
        [HttpGet("priceRange/{min:decimal}/{max:decimal}")]
        public async Task<IActionResult> GetByPriceRangeAsync([FromRoute] decimal min, [FromRoute] decimal max)
        {
            var response = await _stock3Service.GetByPriceRangeAsync(min, max);
            return Ok(response);
        }
        [HttpGet("top/{count:int}")]
        public async Task<IActionResult> GetByPriceTopAsync([FromRoute] int count)
        {
            var response = await _stock3Service.GetByPriceTopAsync(count);
            return Ok(response);
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetByPagination([FromQuery] int page=1, [FromQuery] int pageSize=10, [FromQuery] string sortBy = "id")
        {
            var response = await _stock3Service.GetByPagination(page, pageSize, sortBy);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStock3Dto dto)
        {
            var stock3_response = await _stock3Service.Create(dto);
            return Ok(stock3_response);

        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            var response = await _stock3Service.GetById(id);
            return Ok(response);
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStock3Dto dto)
        {
            var response = await _stock3Service.Update(id, dto);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await _stock3Service.DeleteById(id);
            return Ok(response);
        }
        

    }
}