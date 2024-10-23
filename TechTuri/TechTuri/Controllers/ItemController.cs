using Microsoft.AspNetCore.Mvc;
using TechTuri.Model;

namespace TechTuri.Controllers
{
    public class ItemController : Controller
    {
        private readonly DataContext _context;

        public ItemController(DataContext data) 
        {
            _context = data;
        }

        public async Task<IActionResult> GetItems()
        {
            var items=2;
            return Ok(items);
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
