using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Code.ApplicationLayer.Services.Server.Dtos;
using Code.Domain.Services.Serializer;
using Code.SystemUtilities;
using PlayFab.ClientModels;

namespace Code.ApplicationLayer.Services.Server.Gateways.Catalog
{
    public class CatalogGatewayImpl : CatalogGateway
    {
        private readonly CatalogService _catalogService;
        private readonly SerializerService _serializerService;

        private readonly Dictionary<string, List<CatalogItemDto>> _items;

        public CatalogGatewayImpl(CatalogService catalogService, SerializerService serializerService)
        {
            _catalogService = catalogService;
            _serializerService = serializerService;
            _items = new Dictionary<string, List<CatalogItemDto>>();
        }


        public async Task<IReadOnlyList<CatalogItemDto>> GetItems<T>(string catalogId)
        {
            var alreadyCached = _items.ContainsKey(catalogId);
            
            if (!alreadyCached)
            {
                await GetItemsFromServer<T>(catalogId);
            }

            return GetCachedItems(catalogId);
        }

        private List<CatalogItemDto> GetCachedItems(string catalogId)
        {
            return _items[catalogId];
        }

        //Min 40:30
        private async Task GetItemsFromServer<T>(string catalogId)
        {
            var optionalItems = await _catalogService.GetItems(catalogId);
            
            optionalItems
                .IfPresent(list => ParseCatalogItems<T>(catalogId, list))
                .OrElseThrow(new Exception());
        }

        private void ParseCatalogItems<T>(string catalogId, List<CatalogItem> list)
        {
            var result = new List<CatalogItemDto>(list.Select(item =>ParseCatalogItem<T>(item)));
            _items.Add(catalogId, result);
        }

        private CatalogItemDto ParseCatalogItem<T>(CatalogItem item)
        {
            return new CatalogItemDto(
                item.ItemId,
                item.DisplayName,
                _serializerService.Deserialize<T>(item.CustomData)
            );
        }
    }
}