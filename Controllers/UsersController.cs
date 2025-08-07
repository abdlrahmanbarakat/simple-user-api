using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;
using UserManagementAPI.Repositories;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll() => UserRepository.GetAll();

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = UserRepository.Get(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.Email))
                return BadRequest("Name and Email are required.");

            UserRepository.Add(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, User user)
        {
            if (id != user.Id) return BadRequest("ID mismatch.");

            var existingUser = UserRepository.Get(id);
            if (existingUser is null) return NotFound();

            UserRepository.Update(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingUser = UserRepository.Get(id);
            if (existingUser is null) return NotFound();

            UserRepository.Delete(id);
            return NoContent();
        }
    }
}
