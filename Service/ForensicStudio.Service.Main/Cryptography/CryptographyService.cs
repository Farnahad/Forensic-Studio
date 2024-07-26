using System.Security.Cryptography;
using System.Text;

namespace ForensicStudio.Service.Main.Cryptography;

public class CryptographyService : ICryptographyService
{
    public string Encrypt(string text, string password)
    {
        var bytes = Encoding.Unicode.GetBytes(text);
        using var aes = Aes.Create();
#pragma warning disable SYSLIB0041
        var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, new byte[]
#pragma warning restore SYSLIB0041
        {
            73, 118, 97, 110, 32, 77, 101, 100, 118, 101, 100, 101, 118
        });

        aes.Key = rfc2898DeriveBytes.GetBytes(32);
        aes.IV = rfc2898DeriveBytes.GetBytes(16);

        using (var memoryStream = new MemoryStream())
        {
            using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cryptoStream.Write(bytes, 0, bytes.Length);
                cryptoStream.Close();
            }

            text = Convert.ToBase64String(memoryStream.ToArray());
        }

        return text;
    }

    public string Decrypt(string text, string password)
    {
        text = text.Replace(" ", "+");
        var buffer = Convert.FromBase64String(text);
        using var aes = Aes.Create();
#pragma warning disable SYSLIB0041
        var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, new byte[]
#pragma warning restore SYSLIB0041
        {
            73, 118, 97, 110, 32, 77, 101, 100, 118, 101, 100, 101, 118
        });

        aes.Key = rfc2898DeriveBytes.GetBytes(32);
        aes.IV = rfc2898DeriveBytes.GetBytes(16);

        using (var memoryStream = new MemoryStream())
        {
            using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cryptoStream.Write(buffer, 0, buffer.Length);
                cryptoStream.Close();
            }

            text = Encoding.Unicode.GetString(memoryStream.ToArray());
        }

        return text;
    }

    public void Dispose()
    {
    }
}