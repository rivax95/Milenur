using System;
using System.Collections.Generic;
using Code.ApplicationLayer.Services.Server.Dtos;
using Code.Domain.Services.Serializer;

namespace ApplicationLayer.Services.Server.Gateways.ServerData
{
    public class UserDataGateway : GatewayImpl
    {
        public UserDataGateway(SerializerService serializerService, GetDataService getDataService,
                                   SetDataService setDataService) : base(serializerService, getDataService,
                                                                         setDataService)
        {
        }

        protected override void InitializeTypeToKey(out Dictionary<Type, string> typeToKey)
        {
            typeToKey = new Dictionary<Type, string>
                        {
                            {typeof(IsInitializedDto), "IsInitialized"}
                        };
        }
    }
}
