using System.Collections.Generic;
using System.Threading.Tasks;
using PlayFab.ServerModels;

namespace Code.ApplicationLayer.Services.Server.Gateways.Inventory
{
    public interface InventoryGateway
    {
        public Task GrantUnitsToUser(string userId, List<ItemGrant> units);
    }
}