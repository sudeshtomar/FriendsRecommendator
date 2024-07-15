using FriendsRecommendator.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FriendsRecommendator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecommendationController
    {
        private readonly IRecommendator _recommendator;

        public RecommendationController(IRecommendator recommendator)
        {
            _recommendator = recommendator;
        }

        [HttpGet()]
        [ProducesResponseType<List<string>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<List<string>> Get(int userId)
        {
           return await _recommendator.GetRecommendations(userId);
        }
    }
}
