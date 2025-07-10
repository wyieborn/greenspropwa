namespace GreensProPWA.Server.Controllers
{
    using GreensProPWA.Server.Services;
    using GreensProPWA.Shared.DTO;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == request.Email);
                if (user == null)
                    return Unauthorized("User not found.");

                // Verify hashed password
                bool passwordMatch = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
                if (!passwordMatch)
                    return Unauthorized("Invalid password.");

                var token = JwtTokenHelper.GenerateToken(user, _config);


                return Ok(new { token, email = user.Email, role = user.Role });
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                // _logger.LogError(ex, "Login failed for user {Email}", request.Email);

                return StatusCode(500, "An error occurred during login. Please try again later.");
            }
        }

    }

}
