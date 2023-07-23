using BookShopBLL.IService;
using BookShopBLL.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShopAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NewsController : ControllerBase
	{
		private INewsService _service;
		public NewsController(INewsService newsService)
		{
			_service = newsService;
		}

		// GET: api/<NewsController>
		[HttpGet("all")]
		public async Task<IActionResult> GetAsync()
		{
			return Ok(await _service.GetAsync());
		}

		// GET api/<NewsController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(Guid id)
		{
			var obj = await _service.GetByIdAsync(id);
			if (obj == null) return NotFound();
			return Ok(obj);
		}

		// POST api/<NewsController>
		[HttpPost("add")]
		public async Task<IActionResult> AddAsync([FromBody] NewsVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.AddAsync(request));
		}

		// PUT api/<NewsController>/5
		[HttpPut("update/{id}")]
		public async Task<IActionResult> UpdateAsync([FromBody] NewsVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.UpdateAsync(request));
		}

		// DELETE api/<NewsController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			var obj =await _service.GetByIdAsync(id);
			if (obj == null) return NotFound();
			return Ok(await _service.DeleteAsync(id));
		}
	}
}
