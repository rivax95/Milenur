using System;
using System.Threading.Tasks;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

namespace Code.ApplicationLayer.Services.Server
{
    public class PlayFabLoginEditor : PlayfabLogin
    {
        protected override void Login(TaskCompletionSource<bool> taskCompletionSource)
        {
            var request = new LoginWithCustomIDRequest()
            {
                CreateAccount = true,
                CustomId = "Editor" //unique id for Editor.
            };

            PlayFabClientAPI.LoginWithCustomID(request, result =>
                    OnSuccess(result, taskCompletionSource),
                error => OnError(error, taskCompletionSource)
            );
        }

      
    }
}