using System.Threading.Tasks;
using ApplicationLayer.Services.Server.Gateways.ServerData;
using Code.ApplicationLayer.Services.Server.Dtos;
using Code.Domain.DataAccess;
using Code.Domain.Entities;

namespace Code.ApplicationLayer.DataAccess
{
    public class UserRepository : UserDataAccess
    {
        private readonly Gateway _userDataGateway;
        private User _localUser;

        public UserRepository(Gateway userDataGateway)
        {
            _userDataGateway = userDataGateway;
        }

        public async Task<User> GetLocalUser()
        {
            if (_localUser != null)
                return _localUser;

            var isInitialized = await _userDataGateway.Contains<IsInitializedDto>();
            _localUser = new User(isInitialized);

            return new User(isInitialized);
        }
    }
}