using System.Text.Json;

namespace ForensicStudio.Service.Main.Json;

public class JsonService : IJsonService
{
    public T GetObject<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json);
    }

    public string GetString(object @object)
    {
        return JsonSerializer.Serialize(@object);
    }

    public void Dispose()
    {
    }
}