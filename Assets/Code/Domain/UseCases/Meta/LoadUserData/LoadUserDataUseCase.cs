using System.Threading.Tasks;
using Code.Domain.DataAccess;
using Code.Domain.Entities;
using UnityEngine;

namespace Code.Domain.UseCases
{
    public class LoadUserDataUseCase : UserDataLoader
    {
        private readonly UserDataAccess _userDataAccess;

        public LoadUserDataUseCase(UserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        public async Task Load()
        {
            User localUser = await _userDataAccess.GetLocalUser();
            Debug.Log(localUser.IsInitialized);
        }
    }
}