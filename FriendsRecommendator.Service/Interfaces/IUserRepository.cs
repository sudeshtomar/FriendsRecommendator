using FriendsRecommendator.Service.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsRecommendator.Service.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>?> GetUsers();
    }
}
