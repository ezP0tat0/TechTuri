using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechTuri.Model;
using TechTuri.Services;
using TechTuri.Model.Dtos;
using TechTuri.Model.Data;
namespace TechTuri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public UserController(DataContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet("UserInfo/{uname}")]
        public async Task<IActionResult> GetUSerInfo(string uname)
        {
            var info = await _userService.GetUserInfo(uname);
            return Ok(info);
        }

        [HttpPost("ChangeInfo")]
        public async Task<IActionResult> ChangeInfo(UserInfoChangeDto uc)
        {
            await _userService.InfoChange(uc);
            return Ok();
        }

    }
}
