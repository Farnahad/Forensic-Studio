using System.Text;
using ForensicStudio.Core.Main.Method;
using ForensicStudio.Logic.Windows.Model;
using Microsoft.Win32;

namespace ForensicStudio.Logic.Windows.Extractor;

// FORENSIC
public class UserAssistExtractor
{
    public MethodResult<List<UserAssist>> GetUserAssists()
    {
        var userAssistRegistryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\UserAssist";
        return GetUserAssists(userAssistRegistryPath);
    }

    public MethodResult<List<UserAssist>> GetUserAssists(string userAssistRegistryPath)
    {
        var userAssists = new List<UserAssist>();

        try
        {
            using (RegistryKey userAssistKey = Registry.CurrentUser.OpenSubKey(userAssistRegistryPath))
            {
                if (userAssistKey != null)
                {
                    var userSubKeys = userAssistKey.GetSubKeyNames();

                    foreach (string userSubKey in userSubKeys)
                    {
                        using (RegistryKey userKey = userAssistKey.OpenSubKey(userSubKey))
                        {
                            if (userKey != null)
                            {
                                string[] valueNames = userKey.GetValueNames();

                                foreach (string valueName in valueNames)
                                {
                                    var newUserAssist = new UserAssist();

                                    var valueData = (byte[])userKey.GetValue(valueName);

                                    newUserAssist.Name = valueName;
                                    // ReSharper disable once AssignNullToNotNullAttribute
                                    newUserAssist.Data = Encoding.Unicode.GetString(valueData);

                                    userAssists.Add(newUserAssist);
                                }
                            }
                        }
                    }
                }
                else
                {
                    return new MethodResult<List<UserAssist>>("Registry key not found.");
                }
            }
        }
        catch (Exception exception)
        {
            return new MethodResult<List<UserAssist>>(exception);
        }

        return new MethodResult<List<UserAssist>>(userAssists);
    }
}