using BookShopBLL.IService;
using BookShopBLL.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShopAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private IOrderService _service;
        public OrderController(IOrderService orderService)
        {
            _service = orderService;
        }

        // GET: api/<OrderController>
        [HttpGet("all")]
		public async Task<IActionResult> GetAsync(Guid? idcustomer)
		{
			return Ok(await _service.GetAsync(idcustomer));
		}
		
        // GET: api/<OrderController>
        [HttpGet("active")]
		public async Task<IActionResult> GetActiveAsync(Guid? idcustomer, int? s)
		{
			var obj = await _service.GetActiveAsync(idcustomer, s);
			return Ok(obj);
		}

		// GET api/<OrderController>/5
		[HttpGet("get")]
		public async Task<IActionResult> GetByIdAsync(Guid? id, string? code)
		{
			var obj = await _service.GetByIdAsync(id, code);
			if(obj == null) return NotFound();
			return Ok(obj); 
		}

		// POST api/<OrderController>
		[HttpPost("add")]
		public async Task<IActionResult> AddAsync([FromBody] OrderVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.AddAsync(request));
		}

		// PUT api/<OrderController>/5
		[HttpPut("update/{id}")]
		public async Task<IActionResult> UpdateAsync([FromBody] OrderVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.UpdateAsync(request));
		}

		// DELETE api/<OrderController>/5
		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			var obj = await _service.GetByIdAsync(id, null);
			if(obj == null) return NotFound();
			return Ok(await _service.DeleteAsync(id));
		}
	}
}
