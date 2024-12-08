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
        UserController(DataContext context,IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

    }
}
