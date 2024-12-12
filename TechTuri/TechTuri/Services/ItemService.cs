using TechTuri.Model;
using TechTuri.Model.Dtos;
using TechTuri.Model.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using TechTuri.Mappers;
using AutoMapper;
using static System.Net.Mime.MediaTypeNames;
using TechTuri.Migrations;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Hosting.Server;

namespace TechTuri.Services
{
    public interface IItemService
    {
        Task<List<ItemSmallDto>> GetItems();  //PagedResult<Item>        int pageNumber, int pageSize
        Task<List<ItemSmallDto>> GetItemsByCategory(string cat);//PagedResult<Item>        int pageNumber, int pageSize
        Task<ItemDto> GetOneItem(int itemID);
        Task UploadItem(ItemDto item);
        Task UploadImg(List<IFormFile> pictures);
    }
    public class ItemService : IItemService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public ItemService(DataContext context, IMapper mapper, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }
        public async Task<List<ItemSmallDto>> GetItems() //int pageNumber,int pageSize     PagedResult<Item>
        {
            var items = await _context.Items.ToListAsync();
            List<ItemSmallDto> result = new List<ItemSmallDto>();
            
            //var items = await _context.Items.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            //var result = items.Create(await _context.Items.CountAsync(), pageNumber, pageSize);
            return result;
        }
        public async Task<List<ItemSmallDto>> GetItemsByCategory(string cat)   //PagedResult<Item>   int pageNumber, int pageSize,
        {
            var items = await _context.Items.Where(x => x.category.Equals(cat)).ToListAsync();
            //var items = await _context.Items.Where(x => x.category == cat).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            //var result = items.Create(await _context.Items.CountAsync(), pageNumber, pageSize);

            List<ItemSmallDto> result = new List<ItemSmallDto>();
            foreach (var item in items)
            {
            }

            return result;


        }
        public async Task<ItemDto> GetOneItem(int itemID)
        {
            var it=await _context.Items.Where(x=>x.id == itemID).FirstOrDefaultAsync();
            ItemDto item = new ItemDto();
            _mapper.Map(it, item); //lehet lesz baj

            return item;
        }

        public async Task UploadImg(List<IFormFile> pictures)
        {

            string uploadPath = Path.Combine(AppContext.BaseDirectory, "UploadedImages");
            Console.WriteLine($"Upload path: {uploadPath}");

            if (!Directory.Exists(uploadPath))
            {
                Console.WriteLine("Directory does not exist, creating it...");
                Directory.CreateDirectory(uploadPath);
            }

            foreach (var file in pictures)
            {
                if (file.Length > 0)
                {
                    string uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";
                    string filePath = Path.Combine(uploadPath, uniqueFileName);

                    try
                    {
                        Console.WriteLine($"Saving file: {filePath}");
                        await using var stream = new FileStream(filePath, FileMode.Create);
                        await file.CopyToAsync(stream);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error saving file: {ex.Message}");
                    }
                }
            }

        }

        public async Task UploadItem(ItemDto item)
        {
            var uId = await _context.Users.Where(x => x.username.Equals(item.username)).FirstOrDefaultAsync();
            Item i = new Item()
            {
                name = item.name,
                description = item.description,
                category = item.category,
                date = DateTime.Now,
                price = item.price,
                condition = item.condition,
                location = item.location,
                UserId = uId.id
            };
            await _context.Items.AddAsync(i);
            await _context.SaveChangesAsync();
        }




        private byte[] ImgToBytes(IFormFile f)
        {
            byte[] imgBytes;

            using (var memoryStream = new MemoryStream())
            {
                f.CopyToAsync(memoryStream);
                imgBytes = memoryStream.ToArray();
            }

            return imgBytes;
        }

        private string BytesToImg(byte[] b)
        {
            string base64Image=Convert.ToBase64String(b);
            string imgSrc = $"data:image/jpeg;base64,{base64Image}";

            return imgSrc;
        }

    }
}
