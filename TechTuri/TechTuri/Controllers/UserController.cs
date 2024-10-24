using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechTuri.Model;
using TechTuri.Services;

namespace TechTuri.Controllers
{
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
