using FinalAPI.Models;
using FinalAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Appouser : ControllerBase
    {
        private readonly IApartamenteUserService _service;
        public Appouser(IApartamenteUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComplete()
        {
            return Ok(await _service.GetApartamentCompletAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateRelation([FromBody] ApartamentUserAddRequest req)
        {
            return Ok(await _service.AddUserToApartament(req));
        }


    }
}
