using ForensicStudio.Core.Main.Method;
using ForensicStudio.Logic.Windows.Model;

namespace ForensicStudio.Logic.Windows.Extractor;

// FORENSIC
public class NtfsExtractor
{
    public MethodResult<List<Ntfs>> GetNtfses()
    {
        var directoryPath = @"C:\Path\To\Your\Directory";
        return GetNtfses(directoryPath);
    }

    public MethodResult<List<Ntfs>> GetNtfses(string directoryPath)
    {
        var ntfses = new List<Ntfs>();

        try
        {
            if (Directory.Exists(directoryPath))
            {
                var files = Directory.GetFiles(directoryPath);

                foreach (string filePath in files)
                {
                    var newNtfs = new Ntfs();

                    var fileInfo = new FileInfo(filePath);

                    newNtfs.FileName = fileInfo.Name;
                    newNtfs.FileSize = fileInfo.Length;
                    newNtfs.CreationTime = fileInfo.CreationTime;
                    newNtfs.LastAccessTime = fileInfo.LastAccessTime;
                    newNtfs.LastWriteTime = fileInfo.LastWriteTime;
                    newNtfs.Attributes = fileInfo.Attributes;

                    ntfses.Add(newNtfs);
                }
            }
            else
            {
                return new MethodResult<List<Ntfs>>("Directory not found.");
            }
        }
        catch (Exception exception)
        {
            return new MethodResult<List<Ntfs>>(exception);
        }

        return new MethodResult<List<Ntfs>>(ntfses);
    }
}