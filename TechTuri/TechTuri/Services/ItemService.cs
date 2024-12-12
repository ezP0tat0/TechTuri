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
        Task UploadImg(IEnumerable<PictureDto> pictures);
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
            foreach (var item in items)
            {
                var firstImg = await _context.Pictures.Where(x => x.id == item.id).FirstOrDefaultAsync();
                result.Add(new ItemSmallDto()
                {
                    id = item.id,
                    name = item.name,
                    price = item.price,
                    location = item.location,
                    image = BytesToImg(firstImg.imgData)
                });
            }
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
                var firstImg = await _context.Pictures.Where(x => x.id == item.id).FirstOrDefaultAsync();
                result.Add(new ItemSmallDto()
                {
                    id = item.id,
                    name = item.name,
                    price = item.price,
                    location = item.location,
                    image = BytesToImg(firstImg.imgData) 
                });
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

        public async Task UploadImg(IEnumerable<PictureDto> pictures)
        {
            string uploadFolder = Path.Combine(_env.WebRootPath, "Pictures");

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            foreach (var file in pictures)
            {
                if (file != null && file.Lenght > 0)
                {
                    string fileName = Path.GetFileName(file.Name);
                    string filePath = Path.Combine(uploadFolder, fileName);
                    file.SaveAs=filePath; // Save each file to the specified location
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
