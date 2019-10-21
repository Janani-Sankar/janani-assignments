using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventAPI.Data;
using EventAPI.Domain;
using EventAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventContext _context;
        private readonly IConfiguration _config;
        public EventController(EventContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Items(
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 6)
        {
            var itemsCount = await
                _context.Events.LongCountAsync();

            var items = await _context.Events
                .OrderBy(c => c.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();

      
            var model = new PaginatedItemsViewModel<Event>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Count = itemsCount,
                Data = items
            };

            return Ok(model);
        }

        [HttpGet]
        [Route("[action]/type/{catalogTypeId}/brand/{catalogBrandId}")]
        public async Task<IActionResult> Items(
            int? eventTypeId,
            int? eventCategoryId,
        [FromQuery] int pageIndex = 0,
        [FromQuery] int pageSize = 6)
        {
            var root = (IQueryable<Event>)_context.Events;
            if (eventTypeId.HasValue)
            {
                root =
                    root.Where(c => c.EventTypeID == eventTypeId);
            }
            if (eventCategoryId.HasValue)
            {
                root =
                    root.Where(c => c.EventCategoryID == eventCategoryId);
            }


            var itemsCount = await
                root.LongCountAsync();

            var items = await root
                .OrderBy(c => c.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();

            

            var model = new PaginatedItemsViewModel<Event>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Count = itemsCount,
                Data = items
            };

            return Ok(model);
        }


       
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> CatalogTypes()
        {
            var items = await _context.EventTypes.ToListAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> CatalogBrands()
        {
            var items = await _context.EventCategories.ToListAsync();
            return Ok(items);
        }
    }
}