using System.Collections.Generic;
using System.Threading.Tasks;
using Code.Domain.Entities;

namespace Code.Domain.DataAccess
{
    public interface UnitsDataAccess
    {
        Task<IReadOnlyList<Unit>> GetAllUnits();
    }
}