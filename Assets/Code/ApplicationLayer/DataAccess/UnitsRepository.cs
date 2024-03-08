using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Code.ApplicationLayer.Services.Server.Dtos;
using Code.ApplicationLayer.Services.Server.Gateways.Catalog;
using Code.Domain.DataAccess;
using Code.Domain.Entities;

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
            _units = ParseDtoToEntity(unitsDtos);

            return _units;
        }

        private List<Unit> ParseDtoToEntity(IReadOnlyList<CatalogItemDto> unitsDtos)
        {
            return new List<Unit>(unitsDtos.Select(unitDto =>
            {
                var customData = unitDto.GetCustomData<UnitsCustomData>();
                return new Unit(
                    unitDto.ID,
                    unitDto.DisplayName,
                    customData.Attack,
                    customData.Health
                );
            }));
        }
    }
}