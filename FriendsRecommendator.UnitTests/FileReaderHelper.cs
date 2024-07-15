using System.Text.Json;

namespace FriendsRecommendator.UnitTests
{
    internal class FileReaderHelper<T> where T : class
    {
        public static T? ReadJsonToObject(string filePath)
        {
            var fileInfo = new FileInfo(filePath);

            using StreamReader sr = new StreamReader(fileInfo.FullName);
            var data = sr.ReadToEnd();
            var objectData = JsonSerializer.Deserialize<T>(data);
            return objectData;
        }
    }
}
