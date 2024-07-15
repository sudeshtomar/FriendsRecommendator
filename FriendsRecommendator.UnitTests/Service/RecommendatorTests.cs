using FriendsRecommendator.Service.Interfaces;
using NSubstitute;
using FriendsRecommendator.Service.Services;
using Microsoft.Extensions.Logging;
using Xunit;
using FriendsRecommendator.Service.Model;
using Assert = Xunit.Assert;

namespace FriendsRecommendator.UnitTests.Service
{
    public class RecommendatorTests
    {
        private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();
        private readonly IFriendsMapRepository _friendsMapRepository = Substitute.For<IFriendsMapRepository>();
        private readonly ILogger<Recommendator> _logger = Substitute.For<ILogger<Recommendator>>();
        private readonly IRecommendator _service;

        public RecommendatorTests()
        {
            _service = new Recommendator(_userRepository, _friendsMapRepository, _logger);
        }

        [Fact]
        public void CanGetRecommendation()
        {
            int userId = 1;
            _userRepository.GetUsers().Returns(GetUsers());
            _friendsMapRepository.GetFriendsMap().Returns(GetFriendsmap());

            var result = _service.GetRecommendations(userId);
            Assert.NotNull(result.Result);
        }

        [Fact]
        public void CaNotGetRecommendation()
        {
            int userId = 12;
            _userRepository.GetUsers().Returns(GetUsers());
            _friendsMapRepository.GetFriendsMap().Returns(GetFriendsmap());

            var result = _service.GetRecommendations(userId);
            Assert.True(result.Result.Count == 0);
        }

        private List<User>? GetUsers()
        {
            var path = Path.Combine("Data", "users.json");
            FileInfo fileInfo = new FileInfo(path);
            return FileReaderHelper<List<User>>.ReadJsonToObject(fileInfo.FullName);
        }

        private Dictionary<int, List<int>> GetFriendsmap()
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