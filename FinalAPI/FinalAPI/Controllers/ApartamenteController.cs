using FinalAPI.Models;
using FinalAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartamenteController: ControllerBase
    {
        private readonly IApartamenteService _service;

        public ApartamenteController(IApartamenteService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ApartamentDTO app)
        {
            var user = await _service.CreateAsync(app);
            if(user == null)
                return BadRequest();
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllWithUserAsync());
        }
    }
}
