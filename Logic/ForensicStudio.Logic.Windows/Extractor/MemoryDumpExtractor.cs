using System.Diagnostics;
using ForensicStudio.Core.Main.Method;
using ForensicStudio.Logic.Windows.Model;

namespace ForensicStudio.Logic.Windows.Extractor;

// FORENSIC
public class MemoryDumpExtractor
{
    public MethodResult<MemoryDump> GetMemoryDump()
    {
        var volatilityPath = @"C:\Path\To\Volatility\volatility.exe";
        var memoryDumpPath = @"C:\Path\To\Your\MemoryDump.raw";

        return GetMemoryDump(volatilityPath, memoryDumpPath);
    }

    public MethodResult<MemoryDump> GetMemoryDump(string volatilityPath, string memoryDumpPath)
    {
        var getMemoryDump = new MemoryDump();

        var volatilityPlugin = "pslist";
        var volatilityPluginOptions = "";

        try
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = volatilityPath,
                Arguments = $"-f {memoryDumpPath} {volatilityPlugin} {volatilityPluginOptions}",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process { StartInfo = processStartInfo })
            {
                process.Start();
                getMemoryDump.Output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
            }
        }
        catch (Exception exception)
        {
            return new MethodResult<MemoryDump>(exception);
        }

        return new MethodResult<MemoryDump>(getMemoryDump);
    }
}