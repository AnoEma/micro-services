using Newtonsoft.Json;
using System.Text;

namespace Serializations;

public class SerializationObject : ISerializationObject
{
    public T Deserializer<T>(string value)
    {
        var deserializer = JsonConvert.DeserializeObject<T>(value);
        return deserializer;
    }

    public byte[] SerializerByte<T>(T value) where T : class
    {
        var jsonString = Serializer(value);
        return Encoding.UTF8.GetBytes(jsonString);
    }

    public string Serializer<T>(T value) where T : class
    {
        var json = JsonConvert.SerializeObject(value);
        return json;
    }

    public T DeserializerByte<T>(byte[] value)
    {
        var message = Encoding.UTF8.GetString(value);
        return Deserializer<T>(message);
    }
}