using BookShopBLL.IService;
using BookShopBLL.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShopAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShopController : ControllerBase
	{
		private IShopService _service;
        public ShopController(IShopService shopService)
        {
            _service = shopService;
        }

		// GET: api/<ShopController>
		[HttpGet("all")]
		public async Task<IActionResult> GetAsync()
		{
			return Ok(await _service.GetAsync());
		}

		// GET api/<ShopController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(Guid id)
		{
			var obj = await _service.GetByIdAsync(id);
			if (obj == null) return NotFound();
			return Ok(obj);
		}

		// POST api/<ShopController>
		[HttpPost("add")]
		public async Task<IActionResult> AddAsync([FromBody] ShopVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.AddAsync(request));
		}

		// PUT api/<ShopController>/5
		[HttpPut("update/{id}")]
		public async Task<IActionResult> updateAsync([FromBody] ShopVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.UpdateAsync(request));
		}

		// DELETE api/<ShopController>/5
		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			var obj = await _service.GetByIdAsync(id);
			if (obj == null) return NotFound();
			return Ok(await _service.DeleteAsync(id));
		}
	}
}
