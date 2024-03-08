using System.Threading.Tasks;
using Code.Domain.DataAccess;

namespace Code.Domain.UseCases
{
  
    public class LoadServerDataUseCase : ServerDataLoader
    {
        private readonly UnitsDataAccess _unitsDataAccess;

        public LoadServerDataUseCase(UnitsDataAccess unitsDataAccess)
        {
            _unitsDataAccess = unitsDataAccess;
        }
            
        public async Task Load()
        {
            await _unitsDataAccess.GetAllUnits();
        }
    }
}