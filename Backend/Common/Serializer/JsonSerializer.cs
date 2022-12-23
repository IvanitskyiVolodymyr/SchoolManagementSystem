using System.Text.Json;

namespace Common.Serializer
{
    public class JsonSerializer<T> where T:class
    {
        public static string Serialize(T obj)
        {
            string jsonString = JsonSerializer.Serialize(obj);
            return jsonString;
        }

        public static T? Deserialize(string json)
        {
            T? obj = JsonSerializer.Deserialize<T>(json);
            return obj;
        }
    }
}
