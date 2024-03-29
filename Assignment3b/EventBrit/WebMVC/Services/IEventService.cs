﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.Services
{
    public interface IeventService
    {
        Task<Event> GetEventsAsync(int page, int size,
    int? category, int? type);

        Task<IEnumerable<SelectListItem>> GetCategoriesAsync();
        Task<IEnumerable<SelectListItem>> GetTypesAsync();

    }
}