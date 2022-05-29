using FinalAPI.Entities;
using FinalAPI.Extensions;
using FinalAPI.Models;
using FinalAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;

        public UsersController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.FindAllAsync(e => true));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute(Name = "id")] long id)
        {
            var found = await _repo.FindOneAsync(e => e.ID_User == id);
            if(found == null)
                return NotFound();
            return Ok(found);
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateNew([FromBody] UserDTO usrDto)
        {
            var user = await _repo.CreateAsync(usrDto.ToEntity());
            if (user == null)
                return BadRequest();
            return CreatedAtAction(nameof(GetById), new { id = user.ID_User }, user);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserDTO usrDto)
        {
            var user = await _repo.UpdateAsync(usrDto.ToEntity());
            if(user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            var user = await _repo.DeleteAsync(id);
            if(user == null)
                return NotFound();
            return Ok(user);
        }
    }
}
