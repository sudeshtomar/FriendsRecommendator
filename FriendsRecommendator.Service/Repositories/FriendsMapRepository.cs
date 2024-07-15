using FriendsRecommendator.Service.Interfaces;
using System.Collections.Generic;

namespace FriendsRecommendator.Service.Repositories
{
    public class FriendsMapRepository : IFriendsMapRepository
    {

        public Dictionary<int, List<int>> GetFriendsMap()
        {
          var map = new Dictionary<int, List<int>>()
          {
              {1,new List<int>{2,3,4}},
              {2,new List<int>{1,3,5,6}},
              {3,new List<int>{1,2,6}},
              {4,new List<int>{1,5,7,8}},
              {5,new List<int>{2,4,6}},
              {6,new List<int>{2,3,5,9}},
              {7,new List<int>{4,9}},
              {8,new List<int>{4}},
              {9,new List<int>{6,7}},
              {10,new List<int>{11}},
              {11,new List<int>{10}},
          };

            return map;
        }
    }
}
