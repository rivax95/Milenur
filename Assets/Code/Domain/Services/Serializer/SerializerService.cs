namespace Code.Domain.Services.Serializer
{
    public interface SerializerService
    {
        string Serialize<T>(T data);
        T Deserialize<T>(string data);
    }
}
