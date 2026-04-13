using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static List<User> _users = new List<User>();

        [HttpGet] // Get all users
        public IActionResult GetUsers() => Ok(_users);

        [HttpPost] // Create user
        public IActionResult CreateUser(User user)
        {
            _users.Add(user);
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }

        [HttpPut("{id}")] // Update user
        public IActionResult UpdateUser(int id, User updatedUser)
        {
            var user = _users.Find(u => u.Id == id);
            if (user == null) return NotFound();
            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            return NoContent();
        }

        [HttpDelete("{id}")] // Delete user
        public IActionResult DeleteUser(int id)
        {
            var user = _users.Find(u => u.Id == id);
            if (user == null) return NotFound();
            _users.Remove(user);
            return NoContent();
        }
    }
}
