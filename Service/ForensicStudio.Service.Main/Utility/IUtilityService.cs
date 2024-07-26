using ForensicStudio.Core.Main.Mvvm;

namespace ForensicStudio.Service.Main.Utility;

public interface IUtilityService : IService
{
    string GetMd5Hash(string value);
}