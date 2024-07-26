using ForensicStudio.Core.Main.Mvvm;

namespace ForensicStudio.Service.Main.Cryptography;

public interface ICryptographyService : IService
{
    string Encrypt(string text, string password);
    string Decrypt(string text, string password);
}