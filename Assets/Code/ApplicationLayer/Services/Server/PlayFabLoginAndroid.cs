using System.Threading.Tasks;
using Code.Domain.Services.Server;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.Device;

namespace Code.ApplicationLayer.Services.Server
{
    public class PlayFabLoginAndroid : PlayfabLogin
    {
        protected override void Login(TaskCompletionSource<bool> taskCompletionSource)
        {
            var request = new LoginWithAndroidDeviceIDRequest()
            {
                CreateAccount = true,
                AndroidDeviceId = SystemInfo.deviceUniqueIdentifier,
                OS = SystemInfo.operatingSystem
            };

            PlayFabClientAPI.LoginWithAndroidDeviceID(request, result =>
                    OnSuccess(result, taskCompletionSource),
                error => OnError(error, taskCompletionSource)
            );
        }
    }
}