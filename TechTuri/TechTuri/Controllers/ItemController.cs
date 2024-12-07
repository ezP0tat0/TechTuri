using AutoMapper;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using TechTuri.Model;
using TechTuri.Model.Data;
using TechTuri.Model.Dtos;
using TechTuri.Services;
using static System.Net.Mime.MediaTypeNames;


namespace TechTuri.Controllers
{
    public class ItemController : Controller
    {
        private readonly DataContext _context;
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public ItemController(DataContext data, IItemService itemService, IMapper mapper)
        {
            _context = data;
            _mapper = mapper;
            _itemService = itemService;
        }
        [HttpGet("/items")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResult<ItemDto>))]
        public async Task<IActionResult> GetItems()
        {
            //PagedResult.CheckParameters(ref pageNumber, ref pageSize);
            //var items = await _itemService.GetItems(pageNumber, pageSize);
            //var itemDtos = new PagedResult<ItemDto>
            //{
            //    CurrentPage = items.CurrentPage,
            //    PageSize = items.PageSize,
            //    TotalItems = items.TotalItems,
            //    TotalPages = items.TotalPages,
            //    Items = _mapper.Map<List<ItemDto>>(items.Items)
            //};
            var items = await _itemService.GetItems();

            return Ok(items);
        }
        [HttpGet("/{categ}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResult<ItemSmallDto>))]
        public async Task<IActionResult> ItemsUnderCategory(string categ)//int pageSize, int pageNumber,
        {
            // PagedResult.CheckParameters(ref pageNumber, ref pageSize);
            var items = await _itemService.GetItemsByCategory(categ);
            //var itemSmallDtos = new PagedResult<ItemSmallDto>
            //{
            //    CurrentPage = items.CurrentPage,
            //    PageSize = items.PageSize,
            //    TotalItems = items.TotalItems,
            //    TotalPages = items.TotalPages,
            //    Items = _mapper.Map<List<ItemSmallDto>>(items.Items)
            //};
            return Ok(items);
        }

        [HttpGet("/item/{itemID}")]
        public async Task<IActionResult> GetOneItem(int itemID)
        {
            var item=await _itemService.GetOneItem(itemID);
            return Ok(item);
        }




        [HttpPost("/UploadItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UploadItem([FromForm] ItemDto item)
        {
            await _itemService.UploadItem(item);
            return Ok();
        }


        //[HttpPost("/UploadImg")]
        //public async Task<IActionResult> UploadImg(IFormFile image)
        //{
        //    if (image == null || image.Length == 0)
        //    {
        //        return BadRequest("No file selected.");
        //    }

        //    byte[] imgBytes;

        //    using (var memoryStream = new MemoryStream())
        //    {
        //        await image.CopyToAsync(memoryStream);
        //        imgBytes = memoryStream.ToArray();
        //    }
        //    img im = new img()
        //    {
        //        id = 1,
        //        imgData = imgBytes
        //    };
        //    await _context.imgs.AddAsync(im);
        //    await _context.SaveChangesAsync();



        //        return Ok();
        //}



        public IActionResult Index()
        {
            return View();
        }
    }
}
