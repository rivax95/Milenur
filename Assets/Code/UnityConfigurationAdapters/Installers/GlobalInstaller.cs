using System;
using ApplicationLayer.Services.Serializer;
using ApplicationLayer.Services.Server.Gateways.ServerData;
using Code.ApplicationLayer.DataAccess;
using Code.ApplicationLayer.Services.Server;
using Code.Domain.Services.Server;
using Code.Domain.UseCases;
using UnityEngine;


namespace Code.UnityConfigurationAdapters.Installers
{
    public class GlobalInstaller : MonoBehaviour
    {
        private void Awake()
        {
            var playfabLogin = GetPlatFabLogin();
            var loginUseCase = new LoginUseCase(playfabLogin);

            var playFabGetUserDataService = new PlayFabGetUserDataService();
            var unityJsonSerializer = new UnityJsonSerializer();
            var userDataGateway = new UserDataGateway(unityJsonSerializer,playFabGetUserDataService,null);
            var userDataAccess = new UserRepository(userDataGateway);
            var loadUserDataUseCase = new LoadUserDataUseCase(userDataAccess);
            var initializeGameUseCase = new InitializedGameUseCase(loginUseCase, loadUserDataUseCase);

            initializeGameUseCase.InitGame();
        }

        private AuthenticateService GetPlatFabLogin()
        {
#if UNITY_EDITOR
            return new PlayFabLoginEditor();
#elif UNITY_ANDROID
            return new PlayFabLoginAndroid();
#elif UNITY_IOS
            return new PlayFabLoginIOs();
#else
             throw new Exception("Platform not defined");
#endif
        }
    }
}