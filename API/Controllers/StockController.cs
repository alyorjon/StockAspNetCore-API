
using API.DTOs.Stock;
using API.Interfaces.Stocks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        public IStockService _stockService;
        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _stockService.GetAllAsync();
            return Ok(stocks);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _stockService.GetByIdAsync(id);
            return Ok(stock);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockDto createStockDto)
        {
            var stock = await _stockService.CreateAsync(createStockDto);
            return Ok(stock);
        }
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockDto updateStockDto)
        {
            var stock = await _stockService.UpdateAsync(id, updateStockDto);
            return Ok(stock);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var stock = await _stockService.DeleteByIdAsync(id);
            return Ok(stock);
        }
    }
}