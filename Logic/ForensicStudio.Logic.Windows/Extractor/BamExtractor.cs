using ForensicStudio.Core.Main.Method;
using ForensicStudio.Logic.Windows.Model;

namespace ForensicStudio.Logic.Windows.Extractor;

// FORENSIC
public class BamExtractor
{
    public MethodResult<List<Bam>> GetBams()
    {
        var bamPath = @"C:\Windows\System32\config\SYSTEM";
        var bamRegistryPath = @"ControlSet001\Control\Session Manager\AppCompatCache";

        return GetBams(bamPath, bamRegistryPath);
    }

    public MethodResult<List<Bam>> GetBams(string bamPath, string bamRegistryPath)
    {
        var bams = new List<Bam>();

        try
        {
            //using (var bamKey = RegistryHive.OpenHive(bamPath))
            //{
            //    if (bamKey != null)
            //    {
            //        using (var bamDataKey = bamKey.OpenSubKey(bamRegistryPath))
            //        {
            //            if (bamDataKey != null)
            //            {
            //                foreach (var valueName in bamDataKey.GetValueNames())
            //                {
            //                    var newBam = new Bam
            //                    {
            //                        Name = valueName,
            //                        Data = bamDataKey.GetValue(valueName)
            //                    };

            //                    bams.Add(newBam);
            //                }
            //            }
            //            else
            //                return new MethodResult<List<Bam>>("Bam data key not found.");
            //        }
            //    }
            //    else
            //        return new MethodResult<List<Bam>>("Bam hive not found.");
            //}
        }
        catch (Exception exception)
        {
            return new MethodResult<List<Bam>>(exception);
        }

        return new MethodResult<List<Bam>>(bams);
    }
}