using BookShopBLL.IService;
using BookShopBLL.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShopAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReturnOrderController : ControllerBase
	{
		private IReturnOrderService _service;
        public ReturnOrderController(IReturnOrderService returnOrderService)
        {
            _service = returnOrderService;
        }

		// GET: api/<ReturnOrderController>
		[HttpGet("all")]
		public async Task<IActionResult> GetAsync(Guid? idorder)
		{
			return Ok(await _service.GetAsync(idorder));
		}
				
		// GET api/<ReturnOrderController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(Guid id)
		{
			var obj = await _service.GetByIdAsync(id);
			if (obj == null) return NotFound();
			return Ok(obj);
		}

		// POST api/<ReturnOrderController>
		[HttpPost("add")]
		public async Task<IActionResult> AddAsync([FromBody] ReturnOrderVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.AddAsync(request));
		}

		// PUT api/<ReturnOrderController>/5
		[HttpPut("update/{id}")]
		public async Task<IActionResult> updateAsync([FromBody] ReturnOrderVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.UpdateAsync(request));
		}

		// DELETE api/<ReturnOrderController>/5
		[HttpDelete("update/{id}")]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			var obj = await _service.GetByIdAsync(id);
			if (obj == null) return NotFound();
			return Ok(await _service.DeleteAsync(id));
		}
	}
}
