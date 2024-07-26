using System.Management;
using ForensicStudio.Core.Main.Method;
using ForensicStudio.Logic.Windows.Model;

namespace ForensicStudio.Logic.Windows.Extractor;

// FORENSIC
public class PageFileExtractor
{
    public MethodResult<List<PageFile>> GetPageFiles()
    {
        var pageFiles = new List<PageFile>();

        try
        {
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PageFileUsage"))
            {
                var results = searcher.Get();

                foreach (var o in results)
                {
                    var newPageFile = new PageFile();

                    var result = (ManagementObject)o;

                    newPageFile.Name = (string)result["Name"];
                    newPageFile.CurrentUsage = (string)result["CurrentUsage"];
                    newPageFile.PeakUsage = (string)result["PeakUsage"];
                    newPageFile.AllocatedBaseSize = (string)result["AllocatedBaseSize"];
                    newPageFile.CurrentBaseSize = (string)result["CurrentBaseSize"];
                    newPageFile.Caption = (string)result["Caption"];
                    newPageFile.Description = (string)result["Description"];
                    newPageFile.InstallDate = (string)result["InstallDate"];
                    newPageFile.Status = (string)result["Status"];

                    pageFiles.Add(newPageFile);
                }
            }
        }
        catch (Exception exception)
        {
            return new MethodResult<List<PageFile>>(exception);
        }

        return new MethodResult<List<PageFile>>(pageFiles);
    }
}