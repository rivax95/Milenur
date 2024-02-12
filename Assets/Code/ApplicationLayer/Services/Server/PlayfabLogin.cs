using System;
using System.Threading.Tasks;
using Code.Domain.Services.Server;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

namespace Code.ApplicationLayer.Services.Server
{
    public abstract class PlayfabLogin : AuthenticateService
    {
        private string _userId;

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
            _userId = result.PlayFabId;
            Debug.Log("Login");
        }

        protected void OnError(PlayFabError error, TaskCompletionSource<bool>t)
        {
            
            t.SetResult(false);
            throw new Exception(error.ErrorMessage);

        }
    }
}