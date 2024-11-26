using TechTuri.Model;
using TechTuri.Model.Dtos;
using TechTuri.Model.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace TechTuri.Services
{
    public interface IItemService
    {
        Task<PagedResult<Item>> GetItems(int pageNumber, int pageSize);
        Task<PagedResult<Item>> GetItemsByCategory(int pageNumber, int pageSize,string cat);
        Task<IActionResult> UploadItem(ItemDto item);
    }
    public class ItemService: IItemService
    {
        private readonly DataContext _context;
        public ItemService(DataContext context) 
        {
            _context = context;
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
        public async Task<IActionResult> UploadItem(ItemDto item)
        {
            Item i = new Item(); 
            _context.Items.Add(i);
            await _context.SaveChangesAsync();

            return null;
        }
    }
}
