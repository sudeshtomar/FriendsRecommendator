using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FriendsRecommendator.Service.Interfaces
{
    public interface IRecommendator
    {
        Task<List<string>> GetRecommendations(int userId);
    }
}
