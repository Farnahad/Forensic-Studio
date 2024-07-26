using System.Text;
using ForensicStudio.Core.Main.Method;
using ForensicStudio.Logic.Windows.Model;
using Microsoft.Win32;

namespace ForensicStudio.Logic.Windows.Extractor;

// FORENSIC
public class ShellbagExtractor
{
    public MethodResult<List<Shellbag>> GetShellbags()
    {
        string shellbagRegistryPath = @"Software\Microsoft\Windows\CurrentVersion\Explorer\ComDlg32\LastVisitedPidlMRU";
        return GetShellbags(shellbagRegistryPath);
    }

    public MethodResult<List<Shellbag>> GetShellbags(string shellbagRegistryPath)
    {
        var shellbags = new List<Shellbag>();

        try
        {
            using (var shellbagKey = Registry.CurrentUser.OpenSubKey(shellbagRegistryPath))
            {
                if (shellbagKey != null)
                {
                    var valueNames = shellbagKey.GetValueNames();

                    foreach (var valueName in valueNames)
                    {
                        var newShellbag = new Shellbag();

                        var valueData = (byte[])shellbagKey.GetValue(valueName);
                        // ReSharper disable once AssignNullToNotNullAttribute
                        newShellbag.Info = Encoding.Unicode.GetString(valueData);

                        shellbags.Add(newShellbag);
                    }
                }
                else
                    return new MethodResult<List<Shellbag>>("Registry key not found.");
            }
        }
        catch (Exception exception)
        {
            return new MethodResult<List<Shellbag>>(exception);
        }

        return new MethodResult<List<Shellbag>>(shellbags);
    }
}