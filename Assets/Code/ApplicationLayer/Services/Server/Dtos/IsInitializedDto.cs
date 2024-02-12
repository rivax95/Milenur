using System;
using ApplicationLayer.Services.Server.Gateways.ServerData;
using UnityEngine;

namespace Code.ApplicationLayer.Services.Server.Dtos
{
    [Serializable]
    public class IsInitializedDto : Dto
    {
        [SerializeField] private bool _IsInitializedDto;

        public bool IsInitialized => _IsInitializedDto;
       
    }
}