using System.Threading.Tasks;

namespace Code.Domain.UseCases
{
    public interface UserDataLoader
    {
        Task Load();
    }
}