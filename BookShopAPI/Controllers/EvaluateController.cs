using BookShopBLL.IService;
using BookShopBLL.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShopAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EvaluateController : ControllerBase
	{
		private IEvaluateService _service;
        public EvaluateController(IEvaluateService evaluateService)
        {
            _service = evaluateService;
        }

        // GET: api/<EvaluateController>
        [HttpGet("all")]
		public async Task<IActionResult> GetAsync(Guid? idbook, Guid? idcustomer)
		{
			return Ok(await _service.GetAsync(idbook, idcustomer));
		}

		// GET api/<EvaluateController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(Guid id)
		{
			var obj = await _service.GetByIdAsync(id);
			if (obj == null) return NotFound();
			return Ok(obj);
		}

		// POST api/<EvaluateController>
		[HttpPost("add")]
		public async Task<IActionResult> AddAsync([FromBody] EvaluateVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.AddAsync(request));
		}

		// PUT api/<EvaluateController>/5
		[HttpPut("update/{id}")]
		public async Task<IActionResult> UpdateAsync([FromBody] EvaluateVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.UpdateAsync(request));
		}

		// DELETE api/<EvaluateController>/5
		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			var obj = await _service.GetByIdAsync(id);
			if (obj == null) return NotFound();
			return Ok(await _service.DeleteAsync(id));
		}
	}
}
