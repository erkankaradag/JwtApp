using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JwtApp.Context;
using JwtApp.Jwt;
using JwtApp.Dto;

namespace JwtApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly PatikaJwtDbContext _context;
        private readonly JwtHelper _jwtService;

        public AuthController(PatikaJwtDbContext context, JwtHelper jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto login)
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == login.Email && x.Password == login.Password);

            if (user == null)
            {
                return Unauthorized("Geçersiz kullanıcı bilgisi");
            }

            var token = _jwtService.GenerateToken(user);
            return Ok(new { token });
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetEmail()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            return Ok($"JWT doğrulandı. Kullanıcı e-postası: {email}");
        }
    }
}
