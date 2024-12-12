using AutoMapper;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using TechTuri.Model;
using TechTuri.Model.Data;
using TechTuri.Model.Dtos;
using TechTuri.Services;
//using static System.Net.Mime.MediaTypeNames;


namespace TechTuri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        //[HttpPost("upload")]
        //public async Task<IActionResult> UploadItem(ItemDto item)
        //{
        //    await _itemService.UploadItem(item);
        //    return Ok();
        //}

        [HttpGet()]
       public async Task<IActionResult> GetItems()
        {
            var items = await _itemService.GetItems();

            return Ok(items);
        }


        [HttpGet("categ/{categ}")]
        public async Task<IActionResult> ItemsUnderCategory(string categ)//int pageSize, int pageNumber,
        {
            var items = await _itemService.GetItemsByCategory(categ);
            return Ok(items);
        }

        [HttpGet("{itemID}")]
        public async Task<IActionResult> GetOneItem(int itemID)
        {
            var item=await _itemService.GetOneItem(itemID);
            return Ok(item);
        }

        [HttpPost("pictures")]
        public async Task<IActionResult> UploadPictures(IEnumerable<PictureDto> uploadedFiles)
        {
           await _itemService.UploadImg(uploadedFiles);

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



    }
}
