using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Code.ApplicationLayer.Services.Server.Dtos;
using Code.ApplicationLayer.Services.Server.Gateways.Catalog;
using Code.Domain.DataAccess;
using Code.Domain.Entities;
using UnityEngine;

namespace Code.ApplicationLayer.DataAccess
{
    public class UnitsRepository : UnitsDataAccess
    {
        private readonly CatalogGateway _catalogGateway;
        private const string CatalogID = "Units";
        private List<Unit> _units;

        public UnitsRepository(CatalogGateway catalogGateway)
        {
            _catalogGateway = catalogGateway;
            _units = new List<Unit>();
        }

        public async Task<IReadOnlyList<Unit>> GetAllUnits()
        {
            var unitsDtos = await _catalogGateway.GetItems<UnitsCustomData>(CatalogID);

            _units = new List<Unit>(unitsDtos.Select(ParseUnits));
            return _units;
        }

        private static Unit ParseUnits(CatalogItemDto unitDto)
        {
            return ParseUnit(unitDto);
        }

        private static Unit ParseUnit(CatalogItemDto unitDto)
        {
            Debug.Log($"Parsing unit: {unitDto.ID}");
            var customData = unitDto.GetCustomData<UnitsCustomData>();
            return new Unit(
                unitDto.ID,
                unitDto.DisplayName,
                customData.Attack,
                customData.Health
            );
        }
    }
}