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

namespace TechTuri.Services
{
    public interface IItemService
    {
        Task<List<ItemSmallDto>> GetItems();  //PagedResult<Item>        int pageNumber, int pageSize
        Task<List<ItemSmallDto>> GetItemsByCategory(string cat);//PagedResult<Item>        int pageNumber, int pageSize
        Task<ItemDto> GetOneItem(int itemID);
        Task UploadItem(ItemDto item);
    }
    public class ItemService : IItemService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ItemService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
        public async Task UploadItem(ItemDto item)
        {
            Item i = new Item();
            _mapper.Map(item, i);
            i.date = DateTime.Now;
            await _context.Items.AddAsync(i);
            await _context.SaveChangesAsync();

            List<PictureDto> pictureList = new List<PictureDto>();
            pictureList = item.pictures;

            if (pictureList.Count > 0)
            {
                foreach (var picture in pictureList)
                {
                    

                   
                    Picture p = new Picture()
                    {
                        imgData = ImgToBytes(picture.picture),
                        ItemId = await _context.Items.CountAsync() + 1
                    };
                    await _context.Pictures.AddAsync(p);
                    await _context.SaveChangesAsync();
                }
            }
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
