using ForensicStudio.Core.Main.Method;
using ForensicStudio.Logic.Windows.Model;

namespace ForensicStudio.Logic.Windows.Extractor;

// FORENSIC
public class PrefetchExtractor
{
    public MethodResult<List<Prefetch>> GetPrefetches()
    {
        string prefetchFolderPath = @"C:\Windows\Prefetch";
        return GetPrefetches(prefetchFolderPath);
    }

    public MethodResult<List<Prefetch>> GetPrefetches(string prefetchFolderPath)
    {
        var prefetches = new List<Prefetch>();

        try
        {
            if (Directory.Exists(prefetchFolderPath))
            {
                var prefetchFiles = Directory.GetFiles(prefetchFolderPath, "*.pf");

                foreach (var prefetchFile in prefetchFiles)
                {
                    var newPrefetch = new Prefetch();

                    var prefetchData = File.ReadAllBytes(prefetchFile);

                    newPrefetch.FileName = Path.GetFileName(prefetchFile);
                    newPrefetch.FileSize = prefetchData.Length;

                    prefetches.Add(newPrefetch);
                }
            }
            else
                return new MethodResult<List<Prefetch>>("Prefetch folder not found.");
        }
        catch (Exception exception)
        {
            return new MethodResult<List<Prefetch>>(exception);
        }

        return new MethodResult<List<Prefetch>>(prefetches);
    }
}