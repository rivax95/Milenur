using System;
using System.Threading.Tasks;
using Code.Domain.Services.Server;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

namespace Code.ApplicationLayer.Services.Server.PlayFab
{
    public abstract class PlayfabLogin : AuthenticateService
    {
      
        public string UserId { get; private set; }
        
        public Task Authenticate()
        {
            var tcs = new TaskCompletionSource<bool>();
            Login(tcs);

            return tcs.Task;
        }

        protected abstract void Login(TaskCompletionSource<bool> taskCompletionSource);
        
        protected void OnSuccess(LoginResult result, TaskCompletionSource<bool> taskCompletionSource)
        {
            taskCompletionSource.SetResult(true);
            UserId = result.PlayFabId;
            Debug.Log("Login");
        }

        protected void OnError(PlayFabError error, TaskCompletionSource<bool>t)
        {
            
            t.SetResult(false);
            throw new Exception(error.ErrorMessage);

        }
    }
}