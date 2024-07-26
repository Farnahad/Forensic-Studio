using System.Text;
using ForensicStudio.Core.Main.Method;
using ForensicStudio.Logic.Windows.Model;

namespace ForensicStudio.Logic.Windows.Extractor;

// FORENSIC
public class JumpListExtractor
{
    public MethodResult<JumpList> GetJumpList()
    {
        var jumpListPath = Environment.GetFolderPath(Environment.SpecialFolder.Recent) +
                           @"\AutomaticDestinations\1b4dd67f29cb1962.automaticDestinations-ms";

        return GetJumpList(jumpListPath);
    }

    public MethodResult<JumpList> GetJumpList(string jumpListPath)
    {
        var jumpList = new JumpList();

        try
        {
            if (File.Exists(jumpListPath))
            {
                var jumpListData = File.ReadAllBytes(jumpListPath);

                jumpList.Contents = Encoding.Unicode.GetString(jumpListData);
            }
            else
                return new MethodResult<JumpList>("JumpList file not found.");
        }
        catch (Exception exception)
        {
            return new MethodResult<JumpList>(exception);
        }

        return new MethodResult<JumpList>(jumpList);
    }
}