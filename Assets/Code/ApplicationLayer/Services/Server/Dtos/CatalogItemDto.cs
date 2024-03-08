using ApplicationLayer.Services.Server.Gateways.ServerData;

namespace Code.ApplicationLayer.Services.Server.Dtos
{
    public class CatalogItemDto : Dto
    {
        public readonly string ID;
        public readonly string DisplayName;
        private readonly object _customData;

        public CatalogItemDto(string id, string displayName, object customData)
        {
            ID = id;
            DisplayName = displayName;
            _customData = customData;
        }

        public T GetCustomData<T>()
        {
            return (T) _customData;
        }
    }
}