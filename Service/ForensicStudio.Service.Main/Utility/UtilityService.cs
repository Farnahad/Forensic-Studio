using System.Security.Cryptography;
using System.Text;

namespace ForensicStudio.Service.Main.Utility;

public class UtilityService : IUtilityService
{
    public string GetMd5Hash(string value)
    {
        var hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(value));
        var stringBuilder = new StringBuilder();

        foreach (var num in hash)
            stringBuilder.Append(num.ToString("X2"));

        return stringBuilder.ToString();
    }

    public void Dispose()
    {
    }
}