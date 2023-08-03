using BookShopBLL.IService;
using BookShopBLL.Service;
using BookShopBLL.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShopAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Book_AuthorController : ControllerBase
	{
		private IBook_AuthorService _service;
		public Book_AuthorController(IBook_AuthorService book_AuthorService)
		{
			_service = book_AuthorService;
		}
		// GET: api/<Book_AuthorController>
		[HttpGet("all")]
		public async Task<IActionResult> GetAsync(Guid? idbook, Guid? idauthor)
		{
			return Ok(await _service.GetAsync(idbook, idauthor));
		}

		// GET api/<Book_AuthorController>/5
		[HttpGet("{idbook}/{idauthor}")]
		public async Task<IActionResult> GetByIdAsync(Guid idbook, Guid idauthor)
		{
			var obj = await _service.GetByIdAsync(idbook, idauthor);
			if (obj != null)
			{
				return Ok(obj);
			}
			return NotFound();
		}

		// POST api/<Book_AuthorController>
		[HttpPost("add")]
		public async Task<IActionResult> AddAsync([FromBody] List<Book_AuthorVM> requuest)
		{
			if (requuest == null)
			{
				return BadRequest();
			}
			var result = await _service.AddAsync(requuest);
			return Ok(result);
		}

		// PUT api/<Book_AuthorController>/5
		[HttpPut("update/{idbook}/{idauthor}")]
		public async Task<IActionResult> UpdateAsync([FromBody] Book_AuthorVM request)
		{
			if (request == null)
			{
				return BadRequest();
			}
			var result = await _service.UpdateAsync(request);
			return Ok(result);
		}

		// DELETE api/<Book_AuthorController>/5
		[HttpDelete("delete")]
		public async Task<IActionResult> DeleteAsync(Guid idbook, Guid? idauthor)
		{
			if (idauthor == null)
			{
				var listobj = await _service.GetAsync(idbook, idauthor);
				if (listobj != null) return NotFound();
			}
			var obj = _service.GetByIdAsync(idbook, idauthor);
			if (obj == null)
			{
				return NotFound();
			}
			var result = await _service.DeleteAsync(idbook, idauthor);
			return Ok(result);
		}
	}
}
