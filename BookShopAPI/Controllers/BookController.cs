using BookShopBLL.IService;
using BookShopBLL.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShopAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		private IBookService _service;
        public BookController(IBookService bookService)
        {
            _service = bookService;
        }

        // GET: api/<BookController>
        [HttpGet("all")]
		public async Task<IActionResult> GetAsync(string? name)
		{
			return Ok(await _service.GetAsync(name));
		}

        // GET: api/<BookController>
        [HttpGet("active")]
		public async Task<IActionResult> GetActiveAsync(string? name)
		{
			return Ok(await _service.GetActiveAsync(name));
		}

		// GET api/<BookController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(Guid id)
		{
			var obj = await _service.GetByIdAsync(id);
			if(obj == null) return NotFound();
			return Ok(obj);
		}

		// POST api/<BookController>
		[HttpPost("add")]
		public async Task<IActionResult> AddAsync([FromBody] BookVM request)
		{
			if (request == null) return BadRequest();
			var result = await _service.AddAsync(request);
			return Ok(result);
		}

		// PUT api/<BookController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync([FromBody] BookVM request)
		{
			if (request == null) return NotFound();
			return Ok(await _service.UpdateAsync(request));
		}

		// DELETE api/<BookController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			var obj = await _service.GetByIdAsync(id);
			if(obj == null) return NotFound();
			return Ok(await _service.DeleteAsync(id));
		}
	}
}
