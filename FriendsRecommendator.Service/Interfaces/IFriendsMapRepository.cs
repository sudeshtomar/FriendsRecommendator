using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FriendsRecommendator.Service.Interfaces
{
    public interface IFriendsMapRepository
    {
        Dictionary<int, List<int>> GetFriendsMap();
    }
}
