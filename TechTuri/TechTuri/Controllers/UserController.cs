using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechTuri.Model;
using TechTuri.Services;

namespace TechTuri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUSerService _userService;
        UserController(DataContext context,IMapper mapper, IUSerService userService) 
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet("UserInfo")]
        public async Task<IActionResult> GetUSerInfo(string uname)
        {
            var info = await _userService.GetUserInfo(uname);
            return Ok(info);
        }

    }
}
