using BookShopBLL.IService;
using BookShopBLL.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShopAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BrandController : ControllerBase
	{
		private IBrandService _service;
		public BrandController(IBrandService brandService)
		{
			_service = brandService;
		}

		// GET: api/<BrandController>
		[HttpGet("all")]
		public async Task<IActionResult> GetAsync(string? name)
		{
			return Ok(await _service.GetAsync(name));
		}

		// GET: api/<BrandController>
		[HttpGet("active")]
		public async Task<IActionResult> GetActiveAsync(string? name)
		{
			return Ok(await _service.GetActiveAsync(name));
		}

		// GET api/<BrandController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(Guid id)
		{
			var obj = await _service.GetByIdAsync(id);
			if (obj == null) return NotFound();
			return Ok(obj);
		}

		// POST api/<BrandController>
		[HttpPost("add")]
		public async Task<IActionResult> AddAsync([FromBody] BrandVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.AddAsync(request));
		}

		// PUT api/<BrandController>/5
		[HttpPut("update/{id}")]
		public async Task<IActionResult> UpdateAsync([FromBody] BrandVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.UpdateAsync(request));
		}

		// DELETE api/<BrandController>/5
		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			var obj = await _service.GetByIdAsync(id); 
			if (obj == null) return NotFound();
			return Ok(await _service.DeleteAsync(id));
		}
	}
}
