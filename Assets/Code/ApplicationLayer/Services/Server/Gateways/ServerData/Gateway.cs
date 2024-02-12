using System.Threading.Tasks;
using Code.ApplicationLayer.Services.Server.Dtos;

namespace ApplicationLayer.Services.Server.Gateways.ServerData
{
    public interface Gateway
    {
        Task InitializeData();
        Task<T> Get<T>() where T : Dto;
        Task<bool> Contains<T>() where T : Dto;
        void Set<T>(T data) where T : Dto;
        Task Save();
    }
}