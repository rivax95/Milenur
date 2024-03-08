using System.Threading.Tasks;

namespace Code.Domain.UseCases
{
    public interface ServerDataLoader
    {
        Task Load();
    }
}