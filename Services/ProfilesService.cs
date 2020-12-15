using System;
using latefall2020_dotnet_bloggr.Models;
using latefall2020_dotnet_bloggr.Repositories;

namespace latefall2020_dotnet_bloggr.Services
{
    public class ProfilesService
    {
        private readonly ProfilesRepository _repo;

        public ProfilesService(ProfilesRepository repo)
        {
            _repo = repo;
        }

        public Profile GetOrCreateProfile(Profile userInfo)
        {
            Profile foundProfile = _repo.GetByEmail(userInfo.Email);
            if (foundProfile == null)
            {
                return _repo.Create(userInfo);
            }
            return foundProfile;
        }
    }
}