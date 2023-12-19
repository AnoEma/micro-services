namespace Serializations;

public interface ISerializationObject
{
    string Serializer<T>(T value) where T : class;
    T Deserializer<T>(string value);
    T DeserializerByte<T>(byte[] value);
    byte[] SerializerByte<T>(T value) where T : class;
}