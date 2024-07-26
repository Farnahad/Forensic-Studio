using System.Text;
using ForensicStudio.Core.Main.Method;
using ForensicStudio.Logic.Windows.Model;
using Microsoft.Win32;

namespace ForensicStudio.Logic.Windows.Extractor;

// FORENSIC
public class ShimCacheExtractor
{
    public MethodResult<List<ShimCache>> GetShimCaches()
    {
        string shimCacheRegistryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Custom\ShimCache";
        return GetShimCaches(shimCacheRegistryPath);
    }

    public MethodResult<List<ShimCache>> GetShimCaches(string shimCacheRegistryPath)
    {
        var shimCaches = new List<ShimCache>();

        try
        {
            using (RegistryKey shimCacheKey = Registry.LocalMachine.OpenSubKey(shimCacheRegistryPath))
            {
                if (shimCacheKey != null)
                {
                    var valueNames = shimCacheKey.GetValueNames();

                    foreach (var valueName in valueNames)
                    {
                        var newShimCache = new ShimCache();

                        var valueData = (byte[])shimCacheKey.GetValue(valueName);
                        // ReSharper disable once AssignNullToNotNullAttribute
                        newShimCache.Info = Encoding.Unicode.GetString(valueData);

                        shimCaches.Add(newShimCache);
                    }
                }
                else
                {
                    return new MethodResult<List<ShimCache>>("Registry key not found.");
                }
            }
        }
        catch (Exception exception)
        {
            return new MethodResult<List<ShimCache>>(exception);
        }

        return new MethodResult<List<ShimCache>>(shimCaches);
    }
}