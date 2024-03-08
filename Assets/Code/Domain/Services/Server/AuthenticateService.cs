using System.Threading.Tasks;

namespace Code.Domain.Services.Server
{
    public interface AuthenticateService
    {
        public Task Authenticate();
        public string UserId { get; }
    }
}