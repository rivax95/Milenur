using System.Collections.Generic;
using System.Threading.Tasks;
using Code.SystemUtilities;
using PlayFab.ClientModels;

namespace Code.ApplicationLayer.Services.Server.Gateways.Catalog
{
    public interface CatalogService
    {
        Task<Optional<List<CatalogItem>>> GetItems(string calogId);
    }
}