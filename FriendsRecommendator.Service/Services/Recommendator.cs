using FriendsRecommendator.Service.Interfaces;
using Microsoft.Extensions.Logging;
using FriendsRecommendator.Service.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsRecommendator.Service.Services
{
    public class Recommendator : IRecommendator
    {
        private readonly ILogger _log;
        private readonly IUserRepository _userRepository;
        private readonly IFriendsMapRepository _friendsMapRepository;

        public Recommendator(IUserRepository userRepository, IFriendsMapRepository friendsMapRepository, ILogger<Recommendator> log)
        {
            _userRepository = userRepository;
            _friendsMapRepository = friendsMapRepository;
            _log = log;
        }

        public async Task<List<string>> GetRecommendations(int userId)
        {
            var users = await _userRepository.GetUsers();
            var friendsMap = _friendsMapRepository.GetFriendsMap();
            var userIds = GetFriendsSuggestion(userId, friendsMap);

            var userNames = (from user in users join id in userIds 
                             on user.UserId equals id select user)
                             .Select(x=>x.UserName)
                             .ToList();
            return userNames;
        }

        private async Task<string> MapUser(int userId)
        {
            var users =  await _userRepository.GetUsers();
            var userName=  users.Where(x => x.UserId == userId).Select(x => x.UserName).First();
            return userName;
        }

        private List<int> GetFriendsSuggestion(int userId, Dictionary<int, List<int>> friendsMap)
        {
            if (!friendsMap.ContainsKey(userId))
            {
                _log.LogInformation($"User {userId} doesn't exist in the friend list map");
                return new List<int>();
            }

            var directFriends = new HashSet<int>(friendsMap[userId]);
            var potentialFriends = new Dictionary<int, int>();

            foreach (var friend in directFriends)
            {
                if(!friendsMap.ContainsKey(friend))
                {
                    _log.LogInformation($"Mapping list not found for the user {friend}");
                    continue;
                }
                foreach (var friendsOfFriend in friendsMap[friend])
                {
                    if (friendsOfFriend != userId
                        && !directFriends.Contains(friendsOfFriend)
                        && !potentialFriends.ContainsKey(friendsOfFriend))
                    {
                        potentialFriends[friendsOfFriend] = 0;
                        potentialFriends[friendsOfFriend]++;

                    }
                }
            }
            var users=potentialFriends.Keys.ToList();

            return users;
        }
    }
}
