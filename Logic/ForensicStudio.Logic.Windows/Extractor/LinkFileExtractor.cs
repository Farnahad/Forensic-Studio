using ForensicStudio.Core.Main.Method;
using ForensicStudio.Logic.Windows.Model;

namespace ForensicStudio.Logic.Windows.Extractor;

// FORENSIC
public class LinkFileExtractor
{
    public MethodResult<LinkFile> GetLinkFile()
    {
        var shortcutFilePath = @"C:\Path\To\Your\Shortcut.lnk";
        return GetLinkFile(shortcutFilePath);
    }

    public MethodResult<LinkFile> GetLinkFile(string shortcutFilePath)
    {
        var linkFile = new LinkFile();

        try
        {
            // WshShell shell = new WshShell();

            // IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutFilePath);

            // linkFile.TargetPath = shortcut.TargetPath;
            // linkFile.Arguments = shortcut.Arguments;
            // linkFile.WorkingDirectory = shortcut.WorkingDirectory;
            // linkFile.IconLocation = shortcut.IconLocation;
            // linkFile.Description = shortcut.Description;
            // linkFile.Hotkey = shortcut.Hotkey;

        }
        catch (Exception exception)
        {
            return new MethodResult<LinkFile>(exception);
        }

        return new MethodResult<LinkFile>(linkFile);
    }
}