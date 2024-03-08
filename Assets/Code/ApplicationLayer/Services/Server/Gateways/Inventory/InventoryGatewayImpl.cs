using System.Collections.Generic;
using System.Threading.Tasks;
using PlayFab.ServerModels;

namespace Code.ApplicationLayer.Services.Server.Gateways.Inventory
{
    public class InventoryGatewayImpl :InventoryGateway
    {
        private readonly GrantItemsService _grantItemsService;

        public InventoryGatewayImpl(GrantItemsService grantItemsService)
        {
            _grantItemsService = grantItemsService;
        }
        
        public async Task GrantUnitsToUser(string userId, List<ItemGrant> units)
        {
            await _grantItemsService.GrantItemsToUsers("Units", units);
        }
    }
}