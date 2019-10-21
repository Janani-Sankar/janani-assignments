using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebMVC.Infrastructure;
using WebMVC.Models;

namespace WebMVC.Services
{
    public class EventService : IEventService
    {
        private readonly IHttpClient _client;
        private readonly string _baseUri;
        public EventService(IConfiguration config,
            IHttpClient client)
        {
            _baseUri = $"{config["CatalogUrl"]}/api/catalog/";
            _client = client;
        }
        public async Task<IEnumerable<SelectListItem>> GetBrandsAsync()
        {
            var categoryUri = ApiPaths.Catalog.GetAllCategories(_baseUri);
            var dataString = await _client.GetStringAsync(categoryUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value=null,
                    Text = "All",
                    Selected = true
                }
            };
            var catagories = JArray.Parse(dataString);
            foreach (var category in catagories)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = category.Value<string>("id"),
                        Text = category.Value<string>("brand")
                    }
                 );
            }

            return items;
        }

        public async Task<Event> GetCatalogItemsAsync(int page,
            int size, int? brand, int? type)
        {
            var catalogItemsUri = ApiPaths.Catalog
                            .GetAllEventItems(_baseUri,
                                page, size, brand, type);
            var dataString = await _client.GetStringAsync(catalogItemsUri);
            var response = JsonConvert.DeserializeObject<Event>(dataString);
            return response;
        }

        public async Task<IEnumerable<SelectListItem>> GetTypesAsync()
        {
            var typeUri = ApiPaths.Catalog.GetAllTypes(_baseUri);
            var dataString = await _client.GetStringAsync(typeUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value=null,
                    Text="All",
                    Selected = true
                }
            };

            var types = JArray.Parse(dataString);
            foreach (var type in types)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = type.Value<string>("id"),
                        Text = type.Value<string>("type")
                    }
                 );
            }

            return items;
        }
    }
}