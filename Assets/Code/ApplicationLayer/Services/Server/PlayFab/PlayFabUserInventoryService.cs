using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Code.ApplicationLayer.Services.Server.Gateways.Inventory;
using PlayFab.ServerModels;
using PlayFab;
using UnityEngine;
namespace Code.ApplicationLayer.Services.Server.PlayFab
{
    public class PlayFabUserInventoryService : GrantItemsService
    {
       
          public Task GrantItemsToUsers(string catalogId, List<ItemGrant> itemGrant)
        {
            var taskCompletionSource = new TaskCompletionSource<List<GrantedItemInstance>>();

            GrantItems(catalogId, itemGrant, taskCompletionSource);

            return Task.Run(() => taskCompletionSource.Task);
        }
      

        private void GrantItems(string catalogId, List<ItemGrant> itemGrant,
            TaskCompletionSource<List<GrantedItemInstance>> taskCompletionSource)
        {
            var request = new GrantItemsToUsersRequest
            {
                CatalogVersion = catalogId,
                ItemGrants = itemGrant,
            };
            PlayFabServerAPI
                .GrantItemsToUsers(request,
                    result => OnSuccess(result, taskCompletionSource),
                    error => OnError(error)
                );
        }

        private void OnError(PlayFabError error)
        {
            //taskCompletionSource.SetResult(false);
            throw new Exception(error.GenerateErrorReport());
        }
        
        private void OnSuccess(GrantItemsToUsersResult result,
            TaskCompletionSource<List<GrantedItemInstance>> taskCompletionSource)
        {
            taskCompletionSource.SetResult(result.ItemGrantResults);
            Debug.Log("Grant items");
        }
    }
}