using ForensicStudio.Core.Main.Method;
using ForensicStudio.Logic.Windows.Model;
using Microsoft.Win32;

namespace ForensicStudio.Logic.Windows.Extractor;

// FORENSIC
public class MostRecentlyUsedExtractor
{
    public MethodResult<List<MostRecentlyUsed>> GetMostRecentlyUseds()
    {
        string registryPath = @"Software\Microsoft\Windows\CurrentVersion\Explorer\RecentDocs";
        return GetMostRecentlyUseds(registryPath);
    }

    public MethodResult<List<MostRecentlyUsed>> GetMostRecentlyUseds(string registryPath)
    {
        var mostRecentlyUseds = new List<MostRecentlyUsed>();

        try
        {
            using (var recentDocsKey = Registry.CurrentUser.OpenSubKey(registryPath))
            {
                if (recentDocsKey != null)
                {
                    var valueNames = recentDocsKey.GetValueNames();

                    foreach (var valueName in valueNames)
                    {
                        var newMostRecentlyUsed = new MostRecentlyUsed();

                        // ReSharper disable once PossibleNullReferenceException
                        var valueData = recentDocsKey.GetValue(valueName).ToString();

                        newMostRecentlyUsed.Name = valueName;
                        newMostRecentlyUsed.Data = valueData;

                        mostRecentlyUseds.Add(newMostRecentlyUsed);
                    }
                }
                else
                    return new MethodResult<List<MostRecentlyUsed>>("Registry key not found.");
            }
        }
        catch (Exception exception)
        {
            return new MethodResult<List<MostRecentlyUsed>>(exception);
        }

        return new MethodResult<List<MostRecentlyUsed>>(mostRecentlyUseds);
    }
}