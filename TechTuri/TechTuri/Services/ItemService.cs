using TechTuri.Model;
using TechTuri.Model.Dtos;
using TechTuri.Model.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using TechTuri.Mappers;
using AutoMapper;
using static System.Net.Mime.MediaTypeNames;

namespace TechTuri.Services
{
    public interface IItemService
    {
        Task<PagedResult<Item>> GetItems(int pageNumber, int pageSize);
        Task<PagedResult<Item>> GetItemsByCategory(int pageNumber, int pageSize,string cat);
        Task UploadItem(ItemDto item);
    }
    public class ItemService: IItemService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ItemService(DataContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PagedResult<Item>> GetItems(int pageNumber,int pageSize)
        {
            var items = await _context.Items.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var result = items.Create(await _context.Items.CountAsync(), pageNumber, pageSize);
            return result;
        }
        public async Task<PagedResult<Item>> GetItemsByCategory(int pageNumber, int pageSize,string cat)
        {
            var items = await _context.Items.Where(x => x.category == cat).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var result = items.Create(await _context.Items.CountAsync(), pageNumber, pageSize);
            return result;
        }
        public async Task UploadItem(ItemDto item)
        {
            Item i=new Item();
            _mapper.Map(item, i);
            i.date = DateTime.Now;
            await _context.Items.AddAsync(i);
            await _context.SaveChangesAsync();

            List<PictureDto> pictureList = new List<PictureDto>();
            pictureList=item.pictures;

            if (pictureList.Count > 0)
            {
                foreach (var picture in pictureList)
                {

                    byte[] imgBytes;

                    using (var memoryStream = new MemoryStream())
                    {
                        await picture.picture.CopyToAsync(memoryStream);
                        imgBytes = memoryStream.ToArray();
                    }
                    Picture p = new Picture()
                    {
                        imgData = imgBytes,
                        ItemId = await _context.Items.CountAsync() + 1
                    };
                    await _context.Pictures.AddAsync(p);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
