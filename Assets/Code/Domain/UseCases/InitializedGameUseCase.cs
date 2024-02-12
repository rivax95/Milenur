using System.Threading.Tasks;

namespace Code.Domain.UseCases
{
    public class InitializedGameUseCase :GameInitializer
    {
        private readonly LoginRequester _loginRequester;
        private readonly UserDataLoader _userDataLoader;

        public InitializedGameUseCase(LoginRequester loginRequester, UserDataLoader userDataLoader)
        {
            _loginRequester = loginRequester;
            _userDataLoader = userDataLoader;
        }

        public async void InitGame()
        {
            //login
           await _loginRequester.Login();
           await _userDataLoader.Load();
           //Load user configuration



        }
    }
}