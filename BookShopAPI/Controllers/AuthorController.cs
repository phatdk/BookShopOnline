using BookShopBLL.IService;
using BookShopBLL.Service;
using BookShopBLL.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShopAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorController : ControllerBase
	{
		private IAuthorService _service;
        public AuthorController(IAuthorService authorService)
        {
            _service = authorService;
        }
		// GET: api/<AuthorController>
		[HttpGet("all")]
		public async Task<IActionResult> GetAsync(string? name)
		{
			return Ok(await _service.GetAsync(name));
		}

		// GET: api/<AuthorController>
		[HttpGet("active")]
		public async Task<IActionResult> GetActiveAsync(string? name)
		{
			return Ok(await _service.GetActiveAsync(name));
		}

		// GET api/<AuthorController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(Guid id)
		{
			var obj = await _service.GetByIdAsync(id);
			if (obj != null)
			{
				return Ok(obj);
			}
			return NotFound();
		}

		// POST api/<AuthorController>
		[HttpPost("add")]
		public async Task<IActionResult> AddAsync([FromBody] AuthorVM requuest)
		{
			if (requuest == null)
			{
				return BadRequest();
			}
			var result = _service.AddAsync(requuest);
			return Ok(result);
		}

		// PUT api/<AuthorController>/5
		[HttpPut("update/{id}")]
		public async Task<IActionResult> UpdateAsync([FromBody] AuthorVM request)
		{
			if (request == null)
			{
				return BadRequest();
			}
			var result = _service.UpdateAsync(request);
			return Ok(result);
		}

		// DELETE api/<AuthorController>/5
		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			var obj = _service.GetByIdAsync(id);
			if (obj == null)
			{
				return NotFound();
			}
			var result = _service.DeleteAsync(id);
			return Ok(result);
		}
	}
}
