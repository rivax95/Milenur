using System.Threading.Tasks;

namespace Code.Domain.UseCases.Meta.LoadServerData
{
    public interface ServerDataLoader
    {
        Task Load();
    }
}