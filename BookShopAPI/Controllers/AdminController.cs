using BookShopBLL.IService;
using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShopAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminController : ControllerBase
	{
		private IAdminService _service;
		public AdminController(IAdminService adminService)
		{
			_service = adminService;
		}

		// GET: api/<AdminController>
		[HttpGet("all")]
		public async Task<IActionResult> GetAsync()
		{
			return Ok(await _service.GetAsync());
		}

		// GET: api/<AdminController>
		[HttpGet("active")]
		public async Task<IActionResult> GetActiveAsync()
		{
			return Ok(await _service.GetActiveAsync());
		}

		// GET api/<AdminController>/5
		[HttpGet("get")]
		public async Task<IActionResult> GetByIdAsync(Guid? id, string? address, int? s)
		{
			var obj = await _service.GetByIdAsync(id, address, s);
			if (obj != null)
			{
				return Ok(obj);
			}
			return NotFound();
		}

		// POST api/<AdminController>
		[HttpPost("add")]
		public async Task<IActionResult> AddAsync([FromBody] AdminVM requuest)
		{
			if(requuest == null)
			{
				return BadRequest();
			}
			var result = await _service.AddAsync(requuest);
			return Ok(result);
		}

		// PUT api/<AdminController>/5
		[HttpPut("update/{id}")]
		public async Task<IActionResult> UpdateAsync([FromBody] AdminVM request)
		{
			if(request == null)
			{
				return BadRequest();
			}
			var result = await _service.UpdateAsync(request);
			return Ok(result);
		}

		// DELETE api/<AdminController>/5
		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			var obj =await _service.GetByIdAsync(id, null, 1);
			if(obj == null)
			{
				return NotFound();
			}
			var result = _service.DeleteAsync(id);
			return Ok(result);
		}
	}
}
