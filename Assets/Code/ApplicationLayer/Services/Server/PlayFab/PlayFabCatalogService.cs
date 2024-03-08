using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Code.SystemUtilities;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

namespace Code.ApplicationLayer.Services.Server.Gateways.Catalog
{
    public class PlayFabCatalogService : CatalogService
    {
        public Task<Optional<List<CatalogItem>>> GetItems(string calogId)
        {
            var taskCompletionSource = new TaskCompletionSource<Optional<List<CatalogItem>>>();
            var request = new GetCatalogItemsRequest()
            {
                CatalogVersion = "Units"
            };

            PlayFabClientAPI.GetCatalogItems(request, result => OnSuccess(result, taskCompletionSource), error => OnError(error, taskCompletionSource));
            return Task.Run(() => taskCompletionSource.Task);
        }

        protected void OnSuccess(GetCatalogItemsResult result, TaskCompletionSource<Optional<List<CatalogItem>>> taskCompletionSource)
        {
            taskCompletionSource.SetResult(new Optional<List<CatalogItem>>(result.Catalog));
            Debug.Log("Ok Catalog");
        }

        protected void OnError(PlayFabError error, TaskCompletionSource<Optional<List<CatalogItem>>> t)
        {
            throw new Exception(error.ErrorMessage);
        }
    }
}