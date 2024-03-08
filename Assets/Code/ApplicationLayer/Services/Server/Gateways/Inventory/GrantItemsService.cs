using System.Collections.Generic;
using System.Threading.Tasks;
using PlayFab.ServerModels;

namespace Code.ApplicationLayer.Services.Server.Gateways.Inventory
{
    public interface GrantItemsService
    {
        Task GrantItemsToUsers(string catalogId, List<ItemGrant> itemGrant);
    }
}