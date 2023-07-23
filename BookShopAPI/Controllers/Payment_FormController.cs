using BookShopBLL.IService;
using BookShopBLL.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShopAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Payment_FormController : ControllerBase
	{
		private IPayment_FormService _service;
        public Payment_FormController(IPayment_FormService payment_FormService)
        {
            _service = payment_FormService;
        }

        // GET: api/<Payment_FormController>
        [HttpGet("all")]
		public async Task<IActionResult> GetAsync()
		{
			return Ok(await _service.GetAsync());
		}
		
        // GET: api/<Payment_FormController>
        [HttpGet("active")]
		public async Task<IActionResult> GetActiceAsync()
		{
			return Ok(await _service.GetActiveAsync());
		}

		// GET api/<Payment_FormController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(Guid id)
		{
			return Ok(await _service.GetByIdAsync(id));
		}

		// POST api/<Payment_FormController>
		[HttpPost("add")]
		public async Task<IActionResult> AddAsync([FromBody] Payment_FormVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.AddAsync(request));
		}

		// PUT api/<Payment_FormController>/5
		[HttpPut("update/{id}")]
		public async Task<IActionResult> UpdateAsync([FromBody] Payment_FormVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.UpdateAsync(request));
		}

		// DELETE api/<Payment_FormController>/5
		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			var obj = await _service.GetByIdAsync(id);
			if(obj == null) return NotFound();
			return Ok(await _service.DeleteAsync(id));
		}
	}
}
