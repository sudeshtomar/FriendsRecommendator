using FriendsRecommendator.Service.Interfaces;
using FriendsRecommendator.Service.Model;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections;

namespace FriendsRecommendator.Service.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<List<User>?> GetUsers()
        {
            var usr = JsonSerializer.Serialize(AddUsers());

            var path = Path.Combine("Data", "users.json");
            var fileInfo=new FileInfo(path);

            using StreamReader sr = new StreamReader(fileInfo.FullName);
            var data = await sr.ReadToEndAsync();

            var users = JsonSerializer.Deserialize<List<User>>(data);

            return users;

        }

        private List<User> AddUsers()
        {
            return new List<User> { new User { UserId = 1, UserName = "Sudesh" },
                                    new User { UserId = 2, UserName = "Tomar" }};
        }
    }
}
