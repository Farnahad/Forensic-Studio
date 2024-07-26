using ForensicStudio.Core.Main.Method;
using ForensicStudio.Logic.Windows.Model;
using Microsoft.Win32;

namespace ForensicStudio.Logic.Windows.Extractor;

// FORENSIC
public class AmCacheExtractor
{
    public MethodResult<List<AmCache>> GetAmCaches()
    {
        var amCachePath = @"C:\Windows\AppCompat\Programs\AmCache.hve";
        var amCacheRegistryPath = @"{9E73DB5D-9307-49D6-A3C1-1E05633A7E34}";

        return GetAmCaches(amCachePath, amCacheRegistryPath);
    }

    public MethodResult<List<AmCache>> GetAmCaches(string amCachePath, string amCacheRegistryPath)
    {
        var amCaches = new List<AmCache>();

        try
        {
            using (var amCacheKey = Registry.LocalMachine.OpenSubKey(amCachePath))
            {
                if (amCacheKey != null)
                {
                    using (var amCacheDataKey = amCacheKey.OpenSubKey(amCacheRegistryPath))
                    {
                        if (amCacheDataKey != null)
                        {
                            foreach (string valueName in amCacheDataKey.GetValueNames())
                            {
                                var newAmCache = new AmCache
                                {
                                    Name = valueName,
                                    Data = amCacheDataKey.GetValue(valueName).ToString()
                                };

                                amCaches.Add(newAmCache);
                            }
                        }
                        else
                            return new MethodResult<List<AmCache>>("AmCache data key not found.");
                    }
                }
                else
                    return new MethodResult<List<AmCache>>("AmCache hive not found.");
            }
        }
        catch (Exception exception)
        {
            return new MethodResult<List<AmCache>>(exception);
        }

        return new MethodResult<List<AmCache>>(amCaches);
    }
}