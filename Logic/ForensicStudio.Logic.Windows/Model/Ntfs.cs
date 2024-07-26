namespace ForensicStudio.Logic.Windows.Model;

// FORENSIC
public class Ntfs
{
    public string FileName { get; set; }
    public long FileSize { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime LastAccessTime { get; set; }
    public DateTime LastWriteTime { get; set; }
    public FileAttributes Attributes { get; set; }
}