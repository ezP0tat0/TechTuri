using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechTuri.Services;
using TechTuri.Model;
using TechTuri.Model.Dtos;
using TechTuri.Model.Data;
using TechTuri.Mappers;

namespace TechTuri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var response = await _authService.Login(login);
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            User user = _mapper.Map<RegisterDto, User>(registerDto);
            _mapper.Map<RegisterDto, User>(registerDto);
            await _authService.Register(user, registerDto.password);
            return Ok();
        }
    }
}
