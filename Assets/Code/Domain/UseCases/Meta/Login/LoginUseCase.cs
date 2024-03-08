using System.Threading.Tasks;
using Code.Domain.Services.Server;

namespace Code.Domain.UseCases
{
    public class LoginUseCase : LoginRequester
    {
        private readonly AuthenticateService _authenticateService;

        public LoginUseCase(AuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        public async Task Login()
        {
            await _authenticateService.Authenticate();
        }
    }
}