﻿using AutoMapper;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using TechTuri.Model;
using TechTuri.Model.Data;
using TechTuri.Model.Dtos;
using TechTuri.Services;


namespace TechTuri.Controllers
{
    public class ItemController : Controller
    {
        private readonly DataContext _context;
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public ItemController(DataContext data, IItemService itemService ,IMapper mapper)
        {
            _context = data;
            _mapper = mapper;
            _itemService = itemService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type=typeof(PagedResult<ItemDto>))]
        public async Task<IActionResult> GetItems(int pageNumber,int pageSize)
        {
            PagedResult.CheckParameters(ref pageNumber, ref pageSize);
            var items=await _itemService.GetItems(pageNumber, pageSize);
            var itemDtos = new PagedResult<ItemDto>
            {
                CurrentPage= items.CurrentPage,
                PageSize= items.PageSize,
                TotalItems= items.TotalItems,
                TotalPages= items.TotalPages,
                Items=_mapper.Map<List<ItemDto>>(items.Items)
            };
            return Ok(itemDtos);
        }
        [HttpGet("/{categ}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResult<ItemSmallDto>))]
        public async Task<IActionResult> ItemsUnderCategory(int pageSize,int pageNumber,string categ)
        {
            PagedResult.CheckParameters(ref pageNumber,ref pageSize);
            var items= await _itemService.GetItemsByCategory(pageNumber, pageSize, categ);
            var itemSmallDtos = new PagedResult<ItemSmallDto>
            {
                CurrentPage = items.CurrentPage,
                PageSize = items.PageSize,
                TotalItems = items.TotalItems,
                TotalPages = items.TotalPages,
                Items = _mapper.Map<List<ItemSmallDto>>(items.Items)
            };
            return Ok(itemSmallDtos);
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
