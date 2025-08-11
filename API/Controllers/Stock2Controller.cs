
using API.DTOs;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Stock2Controller : ControllerBase
    {
        #region Constructor 
        public IStock2Service _stock2Service;
        public Stock2Controller(IStock2Service stock2Service)
        {
            _stock2Service = stock2Service;
        }
        #endregion
        #region Get All
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stock = await _stock2Service.GetAll();
            return Ok(stock);
        }
        #endregion
        #region Get By ID
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _stock2Service.GetById(id);
            return Ok(stock);
        }
        #endregion
        #region POST new Stock2
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStock2Dto createStock2Dto)
        {
            var stock = await _stock2Service.Create(createStock2Dto);
            return Ok(stock);
        }
        #endregion
        #region Patch By ID
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStock2Dto updateStock2Dto)
        {
            var stock = await _stock2Service.Update(id, updateStock2Dto);
            return Ok(stock);
        }
        #endregion
        #region Delete by iD
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var stock = await _stock2Service.DeleteById(id);
            return Ok(stock);
        }
        #endregion
    }
}