using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }


    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static List<User> users = new List<User>();

        // 1. GET: Recupera tutti gli utenti
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(users);
        }

        // 2. POST: Aggiunge un nuovo utente
        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            if (user == null || string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email))
            {
                return BadRequest("I dati dell'utente non sono validi.");
            }

            users.Add(user);
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }

        // 3. PUT: Aggiorna un utente esistente
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            var user = users.Find(u => u.Id == id);
            if (user == null)
            {
                return NotFound("Utente non trovato.");
            }

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            return Ok(user);
        }

        // 4. DELETE: Elimina un utente
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = users.Find(u => u.Id == id);
            if (user == null)
            {
                return NotFound("Utente non trovato.");
            }

            users.Remove(user);
            return NoContent();
        }
    }
}
