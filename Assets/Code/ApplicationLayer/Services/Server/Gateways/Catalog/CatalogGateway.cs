using System.Collections.Generic;
using System.Threading.Tasks;
using Code.ApplicationLayer.Services.Server.Dtos;
using PlayFab.ClientModels;

namespace Code.ApplicationLayer.Services.Server.Gateways.Catalog
{
    public interface CatalogGateway
    {
        Task<IReadOnlyList<CatalogItemDto>> GetItems<T>(string catalogId);
    }
}