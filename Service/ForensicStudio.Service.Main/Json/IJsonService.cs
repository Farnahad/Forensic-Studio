using ForensicStudio.Core.Main.Mvvm;

namespace ForensicStudio.Service.Main.Json;

public interface IJsonService : IService
{
    T GetObject<T>(string json);
    string GetString(object @object);
}