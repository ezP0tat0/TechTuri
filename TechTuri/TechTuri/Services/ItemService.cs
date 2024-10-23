﻿using TechTuri.Model;
using TechTuri.Model.Dtos;
using TechTuri.Model.Data;
using Microsoft.EntityFrameworkCore;

namespace TechTuri.Services
{
    public interface IItemService
    {
        Task<PagedResult<Item>> GetItems(int pageNumber, int pageSize);
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
    }
}