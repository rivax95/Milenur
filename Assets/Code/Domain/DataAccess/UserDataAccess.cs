using System.Threading.Tasks;
using Code.Domain.Entities;

namespace Code.Domain.DataAccess
{
    public interface UserDataAccess
    {
        Task<User> GetLocalUser();
    }
}