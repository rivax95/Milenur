using System.Threading.Tasks;
using Code.Domain.DataAccess;
using Code.Domain.UseCases.Meta.LoadServerData;

namespace Code.Domain.UseCases
{
    public class InitializedGameUseCase : GameInitializer
    {
        private readonly LoginRequester _loginRequester;
        private readonly UserDataLoader _userDataLoader;
        private readonly ServerDataLoader _serverDataLoader;

        public InitializedGameUseCase(LoginRequester loginRequester,
            UserDataLoader userDataLoader,
            ServerDataLoader serverDataLoader)
        {
            _loginRequester = loginRequester;
            _userDataLoader = userDataLoader;
            _serverDataLoader = serverDataLoader;
        }

        public async void InitGame()
        {
            //login
            await _loginRequester.Login();
            await _userDataLoader.Load();
            await _serverDataLoader.Load();
            //Load user configuration
        }
    }
}