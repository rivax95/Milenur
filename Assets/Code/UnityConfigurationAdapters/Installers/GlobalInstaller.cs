using System;
using ApplicationLayer.Services.Serializer;
using ApplicationLayer.Services.Server.Gateways.ServerData;
using Code.ApplicationLayer.DataAccess;
using Code.ApplicationLayer.Services.Server;
using Code.ApplicationLayer.Services.Server.Gateways.Catalog;
using Code.ApplicationLayer.Services.Server.Gateways.Inventory;
using Code.ApplicationLayer.Services.Server.PlayFab;
using Code.Domain.Services.Server;
using Code.Domain.UseCases;
using Code.Domain.UseCases.Meta.LoadServerData;
using NaughtyAttributes;
using UnityEngine;


namespace Code.UnityConfigurationAdapters.Installers
{
    public class GlobalInstaller : MonoBehaviour
    {
        private LoadServerDataUseCase serverUseCase;
        private void Awake()
        {
// Login
            var playfabLogin = GetPlatFabLogin();
            var loginUseCase = new LoginUseCase(playfabLogin);
//User Data
            var playFabGetUserDataService = new PlayFabGetUserDataService();

            var unityJsonSerializer = new UnityJsonSerializer();

            var userDataGateway = new UserDataGateway(unityJsonSerializer, playFabGetUserDataService, null);

            var userDataAccess = new UserRepository(userDataGateway);

            var loadUserDataUseCase = new LoadUserDataUseCase(userDataAccess);
//Server Data
            var playFabCatalogService = new PlayFabCatalogService();

            var catalogGateway = new CatalogGatewayImpl(playFabCatalogService, unityJsonSerializer);

            var userInventoryService = new PlayFabUserInventoryService();
            
            var inventoryGateway = new InventoryGatewayImpl(userInventoryService);
            
            var unitsRepository = new UnitsRepository(catalogGateway,inventoryGateway);

            var loadServerDataUseCase = new LoadServerDataUseCase(unitsRepository,playfabLogin);
            serverUseCase = loadServerDataUseCase;
//InitGame
            var initializeGameUseCase = new InitializedGameUseCase(
                    loginUseCase, 
                    loadUserDataUseCase,
                    loadServerDataUseCase
                    );

            initializeGameUseCase.InitGame();
        }

        [Button]
        public void TestLoadServerData()
        {
            serverUseCase.Load();
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