using System.Threading.Tasks;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.Device;

namespace Code.ApplicationLayer.Services.Server
{
    public class PlayFabLoginIOs : PlayfabLogin
    {
        protected override void Login(TaskCompletionSource<bool> taskCompletionSource)
        {
            var request = new LoginWithIOSDeviceIDRequest()
            {
                CreateAccount = true,
                OS = SystemInfo.operatingSystem,
                DeviceId = SystemInfo.deviceUniqueIdentifier
            };

            PlayFabClientAPI.LoginWithIOSDeviceID(request, result =>
                    OnSuccess(result, taskCompletionSource),
                error => OnError(error, taskCompletionSource)
            );
        }
    }
}