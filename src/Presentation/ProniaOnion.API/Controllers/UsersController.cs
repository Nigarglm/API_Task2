
using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.DTOs.Users;
using ProniaOnion.Application.Abstractions.Services;

namespace ProniaOnion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthenticationService _service;
        public UsersController(IAuthenticationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            await _service.Register(dto);
            return NoContent();
        }
    }
}
