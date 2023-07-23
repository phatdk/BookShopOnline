using BookShopBLL.IService;
using BookShopBLL.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShopAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private ICustomerService _service;
        public CustomerController(ICustomerService customerService)
        {
            _service = customerService;
        }

        // GET: api/<CustomerController>
        [HttpGet("all")]
		public async Task<IActionResult> GetAsync(string? name)
		{
			return Ok(await _service.GetAsync(name));
		}
		
        // GET: api/<CustomerController>
        [HttpGet("active")]
		public async Task<IActionResult> GetActiveAsync(string? name)
		{
			return Ok(await _service.GetActiveAsync(name));
		}

		// GET api/<CustomerController>/5
		[HttpGet("get")]
		public async Task<IActionResult> GetByIdAsync(Guid? id, string? address, int s)
		{
			var obj = await _service.GetByIdAsync(id, address, s);
			if(obj == null) return NotFound();
			return Ok(obj);
		}

		// POST api/<CustomerController>
		[HttpPost("add")]
		public async Task<IActionResult> AddAsync([FromBody] CustomerVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.AddAsync(request));
		}

		// PUT api/<CustomerController>/5
		[HttpPut("update/{id}")]
		public async Task<IActionResult> UpdateAsync([FromBody] CustomerVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.UpdateAsync(request));
		}

		// DELETE api/<CustomerController>/5
		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			var obj = await _service.GetByIdAsync(id, null, 1);
			if(obj == null) return NotFound();
			return Ok(await _service.DeleteAsync(id));
		}
	}
}
