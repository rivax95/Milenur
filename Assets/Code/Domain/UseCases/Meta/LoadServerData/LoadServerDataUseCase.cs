using System.Collections.Generic;
using System.Threading.Tasks;
using Code.Domain.DataAccess;
using Code.Domain.Services.Server;
using Code.SharedTypes.Units;

namespace Code.Domain.UseCases.Meta.LoadServerData
{
    public class LoadServerDataUseCase : ServerDataLoader
    {
        private readonly UnitsDataAccess _unitsDataAccess;
        private readonly AuthenticateService _authenticateService;

        public LoadServerDataUseCase(UnitsDataAccess unitsDataAccess, AuthenticateService authenticateService)
        {
            _unitsDataAccess = unitsDataAccess;
            _authenticateService = authenticateService;
        }

        public async Task Load()
        {
            await _unitsDataAccess.GetAllUnits();
            //Lo meto aqui para probar que funciona, ya le hare su use case
            await _unitsDataAccess.AddUnitsToUser(_authenticateService.UserId,
                new List<UnitToAdd> { new UnitToAdd("Unit003", new UnitState(12, 1)) });
        }
    }
}