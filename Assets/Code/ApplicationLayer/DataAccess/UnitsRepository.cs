using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Code.ApplicationLayer.Services.Server.Dtos;
using Code.ApplicationLayer.Services.Server.Gateways.Catalog;
using Code.ApplicationLayer.Services.Server.Gateways.Inventory;
using Code.Domain.DataAccess;
using Code.Domain.Entities;
using PlayFab.ServerModels;
using UnityEngine;

namespace Code.ApplicationLayer.DataAccess
{
    public class UnitsRepository : UnitsDataAccess
    {
        private readonly CatalogGateway _catalogGateway;
        private readonly InventoryGateway _inventoryGateway;
        private const string CatalogID = "Units";
        private List<Unit> _units;

        public UnitsRepository(CatalogGateway catalogGateway , InventoryGateway inventoryGateway)
        {
            _catalogGateway = catalogGateway;
            _inventoryGateway = inventoryGateway;
            _units = new List<Unit>();
        }

        public async Task<IReadOnlyList<Unit>> GetAllUnits()
        {
            var unitsDtos = await _catalogGateway.GetItems<UnitCustomData>(CatalogID);

            _units = new List<Unit>(unitsDtos.Select(UnitMapper.ParseUnits));
            return _units;
        }

        public async Task AddUnitsToUser(string userId, List<UnitToAdd> units)
        {
            var items = new List<ItemGrant>(units.Select(unit => new ItemGrant()
                {
                    ItemId = unit.Id,
                    Data = ParseFieldsToDictionary(unit),
                    PlayFabId = userId
                }
            ));
            await _inventoryGateway.GrantUnitsToUser(userId, items);
        }

        //Remember is better because if unittoadd class have any field change this method it would still work correctly (generic code!!)
        private static Dictionary<string, string> ParseFieldsToDictionary(UnitToAdd unit)
        {
            Dictionary<string, string> DataParse = new Dictionary<string, string>();
            var type = unit.UnitState.GetType();
            var fieldInfos = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            DataParse= fieldInfos.ToDictionary(field => field.Name, field => field.GetValue(unit.UnitState).ToString());
            
            return DataParse;
        }
      
    }
}