using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SafeVault.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {
        // Endpoint per admin
        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminDashboard()
        {
            return Ok(new { message = "Benvenuto nella dashboard admin!" });
        }

        // Endpoint per utenti
        [HttpGet("user")]
        [Authorize(Roles = "User")]
        public IActionResult UserDashboard()
        {
            return Ok(new { message = "Benvenuto nella dashboard utente!" });
        }
    }
}
